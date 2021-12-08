using FundooModels;
using FundooRepository.Context;
using Microsoft.Extensions.Configuration;
using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using StackExchange.Redis;

namespace FundooRepository.Interface
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext userContext;
        public UserRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }
        public IConfiguration Configuration { get; }
        public string Register(RegisterModel registerModel)
        {
            try
            {
                var validEmail = this.userContext.Users.Where(x => x.Email == registerModel.Email).FirstOrDefault();
                if (validEmail == null)
                {
                    if (registerModel != null)
                    {
                        registerModel.Password = this.EncryptPassword(registerModel.Password);
                        this.userContext.Add(registerModel);
                        this.userContext.SaveChanges();
                        return "Registration Successful!";
                    }
                    return "Registration UnSuccessful!";
                }
                else
                    return "Email already Exist!";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public string LogIn(LoginModel loginModel)
        {
            try
            {
                var validEmail = this.userContext.Users.Where(x => x.Email == loginModel.Email).FirstOrDefault();
                var validPassword = this.userContext.Users.Where(x => x.Password == loginModel.Password).FirstOrDefault();
                validPassword.Password = EncryptPassword(loginModel.Password);
                if (validEmail == null && validPassword == null)
                {
                    return "Login UnSuccessful";
                }
                else if(validEmail == null)
                {
                    return "Given email is incorrect";
                }
                else if(validPassword == null)
                {
                    return "Enter password is incorrect";
                }
                else
                {
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    database.StringSet(key: "Firstname", validEmail.FirstName);
                    database.StringSet(key: "Lastname", validEmail.LastName);
                    database.StringSet(key: "UserId", validEmail.UserID.ToString());
                    this.userContext.Update(validEmail);
                    return "Login Successful ";
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string EncryptPassword(string password)
        {
            var encodedPassword = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(encodedPassword);
        }
        public string ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            try
            {
                var validEmailId = this.userContext.Users.Where(x => 
                x.Email == resetPasswordModel.Email).FirstOrDefault();
                if (validEmailId != null)
                {
                    validEmailId.Password = EncryptPassword(resetPasswordModel.NewPassword);
                    this.userContext.SaveChanges();
                    return "Password is updated";
                }
                return "Password is not updated";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string ForgotPassword(string emailId)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(this.Configuration["Credentials:testEmailId"]);
                mail.To.Add(emailId);
                mail.Subject = "Test Mail";
                SendMSMQ();
                mail.Body = ReceiveMSMQ();
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(
                    this.Configuration["Credentials:testEmailId"], 
                    this.Configuration["Credentials:testEmailPassword"]);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return "Email is sent sucessfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void SendMSMQ()
        {
            MessageQueue messageQueue;
            if (MessageQueue.Exists(@".\Private$\FundooNotes"))
            {
                messageQueue = new MessageQueue(@".\Private$\FundooNotes");
            }
            else
            {
                messageQueue = MessageQueue.Create(@".\Private$\FundooNotes");
            }
            string body = "This is for Testing SMTP mail from GMAIL";
            messageQueue.Label = "Mail Body";
            messageQueue.Send(body);
        }
        public string ReceiveMSMQ()
        {
            MessageQueue messageQueue = new MessageQueue(@".\Private$\FundooNotes");
            var receivemsg = messageQueue.Receive();
            return receivemsg.ToString();
        }
        public string JwtToken(string email)
        {
            byte[] key = Encoding.UTF8.GetBytes(this.Configuration["SecretKey"]);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                      new Claim(ClaimTypes.Name, email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}

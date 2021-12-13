// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Magic Soft">
//   Copyright © 2021 Company="Magic Soft"
// </copyright>
// <creator name="Saddam Khan"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooRepository.Interface
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net.Mail;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Experimental.System.Messaging;
    using FundooModels;
    using FundooRepository.Context;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using StackExchange.Redis;

    /// <summary>
    /// User Repository class has functions for registration,log in,reset password and forget password
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// User Context Objects
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class
        /// </summary>
        /// <param name="configuration">IConfiguration configuration</param>
        /// <param name="userContext">UserContext userContext</param>
        public UserRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }

        /// <summary>
        /// Gets the Configuration object of IConfiguration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Adding a new User to the database
        /// </summary>
        /// <param name="registerModel">passing parameter of type RegisterModel</param>
        /// <returns>Returns string if Registration is successful or unsuccessful</returns>
        public async Task<string> Register(RegisterModel registerModel)
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
                        await this.userContext.SaveChangesAsync();
                        return "Registration Successful!";
                    }

                    return "Registration UnSuccessful!";
                }
                else
                {
                    return "Email already Exist!";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Login method finds user in database and permit him to login
        /// </summary>
        /// <param name="loginModel">passing parameter of type LoginModel</param>
        /// <returns>Returns string if Login is successful or unsuccessful</returns>
        public string LogIn(LoginModel loginModel)
        {
            try
            {
                var validEmail = this.userContext.Users.Where(x => x.Email == loginModel.Email).FirstOrDefault();
                var validPassword = this.userContext.Users.Where(x => x.Password == loginModel.Password).FirstOrDefault();
                validPassword.Password = this.EncryptPassword(loginModel.Password);
                if (validEmail == null && validPassword == null)
                {
                    return "Login UnSuccessful";
                }
                else if (validEmail == null)
                {
                    return "Given email is incorrect";
                }
                else if (validPassword == null)
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

        /// <summary>
        /// Method to Encryption of password
        /// </summary>
        /// <param name="password">passes password as string</param>
        /// <returns>returns of encrypted password in the form of hexadecimal string</returns>
        public string EncryptPassword(string password)
        {
            var encodedPassword = Encoding.UTF8.GetBytes(password);

            return Convert.ToBase64String(encodedPassword);
        }

        /// <summary>
        /// Reset the password of a user
        /// </summary>
        /// <param name="resetPasswordModel">Reset Password Model resetPasswordModel</param>
        /// <returns>Returns string if the password is successfully reset or Not</returns>
        public async Task<string> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            try
            {
                var validEmailId = this.userContext.Users.Where(x => 
                x.Email == resetPasswordModel.Email).FirstOrDefault();
                if (validEmailId != null)
                {
                    ////Encrypting the password
                    validEmailId.Password = this.EncryptPassword(resetPasswordModel.NewPassword);
                    ////Update the data in the database
                    await this.userContext.SaveChangesAsync();
                    return "Password is updated";
                }

                return "Password is not updated";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Forgot password method performs sending mail to user,for creating new password
        /// </summary>
        /// <param name="emailId">Passing parameter as a emailId of type string</param>
        /// <returns>Returns a string value as mail sent successfully</returns>
        public string ForgotPassword(string emailId)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(this.Configuration["Credentials:testEmailId"]);
                mail.To.Add(emailId);
                mail.Subject = "Test Mail";
                this.SendMSMQ();
                mail.Body = this.ReceiveMSMQ();
                smtpServer.Port = 587;
                smtpServer.Credentials = new System.Net.NetworkCredential(
                    this.Configuration["Credentials:testEmailId"], 
                    this.Configuration["Credentials:testEmailPassword"]);
                smtpServer.EnableSsl = true;
                smtpServer.Send(mail);
                return "Email is sent sucessfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Sending message through MSMQ
        /// </summary>
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

        /// <summary>
        /// For reading message from MSMQ
        /// </summary>
        /// <returns>Returns the message in the queue is sent successfully</returns>
        public string ReceiveMSMQ()
        {
            MessageQueue messageQueue = new MessageQueue(@".\Private$\FundooNotes");
            var receivemsg = messageQueue.Receive();
            receivemsg.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            return receivemsg.Body.ToString();
        }

        /// <summary>
        /// Generating a JWT token
        /// </summary>
        /// <param name="email">Passing Parameter as a emailId of type string</param>
        /// <returns>Returns a string of token</returns>
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

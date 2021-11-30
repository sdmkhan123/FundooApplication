using FundooModels;
using FundooRepository.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                if (validEmail == null && validPassword == null)
                {
                    return "Login UnSuccessful";
                }
                else
                {
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
                var validEmailId = this.userContext.Users.Where(x => x.Email == resetPasswordModel.Email).FirstOrDefault();
                if (validEmailId != null)
                {
                    validEmailId.Password = EncryptPassword(resetPasswordModel.NewPassword);
                    this.userContext.Update(validEmailId);
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
            return "";
        }
    }
}

using FundooModels;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Interface
{
    public class UserManager : IUserManager
    {
        //Declaring obj for the IUserRepository
        private readonly IUserRepository repository;
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }
        public string Register(RegisterModel registerModel)
        {
            try
            {
                return this.repository.Register(registerModel);
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
                return this.repository.LogIn(loginModel);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public string ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            try
            {
                return this.repository.ResetPassword(resetPasswordModel);
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
                return this.repository.ForgotPassword(emailId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

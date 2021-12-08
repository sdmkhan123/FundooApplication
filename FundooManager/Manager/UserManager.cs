// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="Magic Soft">
//   Copyright © 2021 Company="Magic Soft"
// </copyright>
// <creator name="Saddam Khan"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooManager.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FundooModels;
    using FundooRepository.Interface;

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

        public string JwtToken(string email)
        {
            try
            {
                return this.repository.JwtToken(email);
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

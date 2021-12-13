// *************************************************************************
// <copyright file="UserManager.cs" company="Magic Soft">
//   Copyright © 2021 Company="Magic Soft"
// </copyright>
// <creator name="Saddam Khan"/>
// *************************************************************************

namespace FundooManager.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using FundooModels;
    using FundooRepository.Interface;

    /// <summary>
    /// Class user manager
    /// </summary>
    public class UserManager : IUserManager
    {
        /// <summary>
        /// Declaring object for the IUserRepository
        /// </summary>
        private readonly IUserRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager"/> class
        /// </summary>
        /// <param name="repository">taking repository as parameter</param>
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Register method for manager class
        /// </summary>
        /// <param name="registerModel">passing register model</param>
        /// <returns>Returns string if Registration is successful</returns>
        public async Task<string> Register(RegisterModel registerModel)
        {
            try
            {
                return await this.repository.Register(registerModel);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Login method finds user in database and permit him to login
        /// </summary>
        /// <param name="loginModel">LoginModel loginDetails</param>
        /// <returns>returns string if login is successful or Unsuccessful</returns>
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

        /// <summary>
        /// Generating a JWT token
        /// </summary>
        /// <param name="email">passing email as a parameter of type string</param>
        /// <returns>Returns a string of token</returns>
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

        /// <summary>
        /// Method for Resetting new Password
        /// </summary>
        /// <param name="resetPasswordModel">Passing resetPasswordModel of type ResetPasswordModel</param>
        /// <returns>Returns string if the password is successfully reset</returns>
        public async Task<string> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            try
            {
                return await this.repository.ResetPassword(resetPasswordModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Forgot password method performs sending mail to user,for creating new password
        /// </summary>
        /// <param name="emailId">string email</param>
        /// <returns>Returns a string value as mail sent successfully</returns>
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

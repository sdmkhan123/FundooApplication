// *************************************************************************
// <copyright file="IUserManager.cs" company="Magic Soft">
//   Copyright © 2021 Company="Magic Soft"
// </copyright>
// <creator name="Saddam Khan"/>
// *************************************************************************

namespace FundooManager.Interface
{
    using FundooModels;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface IUserManager
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Adding a new user
        /// </summary>
        /// <param name="registerModel">passing registerModel of type RegisterModel</param>
        /// <returns>return string</returns>
        Task<string> Register(RegisterModel registerModel);

        /// <summary>
        /// Login by user
        /// </summary>
        /// <param name="loginModel">passing registerModel of type RegisterModel</param>
        /// <returns>return string</returns>
        string LogIn(LoginModel loginModel);

        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="resetPasswordModel">Passing resetPasswordModel of type ResetPasswordModel</param>
        /// <returns>return string</returns>
        Task<string> ResetPassword(ResetPasswordModel resetPasswordModel);

        /// <summary>
        /// forget password
        /// </summary>
        /// <param name="email">passing email string</param>
        /// <returns>return string</returns>
        string ForgotPassword(string email);

        /// <summary>
        /// used to get JWTToken
        /// </summary>
        /// <param name="email">passing email string</param>
        /// <returns>return string</returns>
        string JwtToken(string email);
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="Magic Soft">
//   Copyright © 2021 Company="Magic Soft"
// </copyright>
// <creator name="Saddam Khan"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooRepository.Interface
{
    using FundooModels;
    using FundooRepository.Context;
    using Microsoft.Extensions.Configuration;
    using System.Threading.Tasks;

    public interface IUserRepository
    {
        Task<string> Register(RegisterModel userData);

        string LogIn(LoginModel login);

        Task<string> ResetPassword(ResetPasswordModel userData);

        string ForgotPassword(string emailId);

        string JwtToken(string email);
    }
}
using FundooModels;

namespace FundooManager.Interface
{
    public interface IUserManager
    {
        string Register(RegisterModel userData);
        string LogIn(LoginModel login);
        string ResetPassword(ResetPasswordModel reset);
        string ForgotPassword(string email);
    }
}
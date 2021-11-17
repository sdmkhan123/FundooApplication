using FundooModels;
using FundooRepository.Context;
using Microsoft.Extensions.Configuration;

namespace FundooRepository.Interface
{
    public interface IUserRepository
    {
        IConfiguration Configuration { get; }

        string Register(RegisterModel userData);
    }
}
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

        public string Register(RegisterModel userData)
        {
            try
            {
                return this.repository.Register(userData);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string Login(LoginModel login)
        {
            try
            {
                return this.repository.Login(login);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

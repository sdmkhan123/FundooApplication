using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Interface
{
    public class UserManager : IUserManager
    {
        //Declaring obj for the IUserRepository
        private readonly IUserManager manager;

        public UserManager(IUserManager manager)
        {
            this.manager = manager;
        }
        //register pass the user data to the repository
        public string Register(RegisterModel userData)
        {
            try
            {
                return this.manager.Register(userData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

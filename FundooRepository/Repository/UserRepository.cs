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
        public string Register(RegisterModel userData)
        {
            try
            {
                var validEmail = this.userContext.Users.Where(x => x.Email == userData.Email).FirstOrDefault();
                if (validEmail == null)
                {
                    if (userData != null)
                    {
                        //Add  the data to Data Base using User Context
                        this.userContext.Add(userData);
                        //Save the change in the Data Base
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
    }
}

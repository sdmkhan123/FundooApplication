using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Repository
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly UserContext userContext;
        public IConfiguration Configuration { get; }
        public CollaboratorRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }
        public string AddCollaborator(CollaboratorModel collaboratorModel)
        {
            try
            {
                if (collaboratorModel != null)
                {
                    this.userContext.Add(collaboratorModel);
                    this.userContext.SaveChanges();
                    return "Collaborator added successfully";
                }
                return "Collaborator not added successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

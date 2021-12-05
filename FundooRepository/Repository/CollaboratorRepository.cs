using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public string DeleteCollaborator(int collaboratorId)
        {
            try
            {
                var collabIdCheck = this.userContext.Collaborators.Where(x => x.CollaboratorId == collaboratorId).FirstOrDefault();
                if (collabIdCheck != null)
                {
                    if (collaboratorId != 0)
                    {
                        this.userContext.Remove(collabIdCheck);
                        this.userContext.SaveChanges();
                        return "Collaborator deleted successfully";
                    }
                    return "Nothing is present inside the collaborator body";
                }
                return "This collaborator does not exist. Kindly create a new one.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

using FundooManager.Interface;
using FundooModels;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class CollaboratorManager : ICollaboratorManager
    {
        private readonly ICollaboratorRepository CollaboratorRepository;
        public CollaboratorManager(ICollaboratorRepository repository)
        {
            this.CollaboratorRepository = repository;
        }
        public string AddCollaborator(CollaboratorModel collaboratorModel)
        {
            try
            {
                return this.CollaboratorRepository.AddCollaborator(collaboratorModel);
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
                return this.CollaboratorRepository.DeleteCollaborator(collaboratorId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<CollaboratorModel> GetCollaboratorDetails(int noteId)
        {
            try
            {
                return this.CollaboratorRepository.GetCollaboratorDetails(noteId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}

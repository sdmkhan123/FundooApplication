using FundooModels;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace FundooRepository.Interface
{
    public interface ICollaboratorRepository
    {
        IConfiguration Configuration { get; }

        string AddCollaborator(CollaboratorModel collaboratorModel);
        string DeleteCollaborator(int collaboratorId);
        IEnumerable<CollaboratorModel> GetCollaboratorDetails(int noteId);
    }
}
using FundooModels;
using System.Collections.Generic;

namespace FundooManager.Interface
{
    public interface ICollaboratorManager
    {
        string AddCollaborator(CollaboratorModel collaboratorModel);
        string DeleteCollaborator(int collaboratorData);
        IEnumerable<CollaboratorModel> GetCollaboratorDetails(int noteId);
    }
}
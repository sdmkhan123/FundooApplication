using FundooModels;
using Microsoft.Extensions.Configuration;

namespace FundooRepository.Interface
{
    public interface ICollaboratorRepository
    {
        IConfiguration Configuration { get; }

        string AddCollaborator(CollaboratorModel collaboratorModel);
    }
}
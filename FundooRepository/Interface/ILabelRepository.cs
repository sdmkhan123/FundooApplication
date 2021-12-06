using FundooModels;
using Microsoft.Extensions.Configuration;

namespace FundooRepository.Interface
{
    public interface ILabelRepository
    {
        IConfiguration Configuration { get; }

        string AddLabelByUserId(LabelModel labelModel);
    }
}
using FundooModels;
using Microsoft.Extensions.Configuration;

namespace FundooRepository.Interface
{
    public interface ILabelRepository
    {
        IConfiguration Configuration { get; }

        string AddLabelByUserId(LabelModel labelModel);
        string AddLabelByNoteId(LabelModel labelModel);
        string DeleteLabel(int userId, string labelName);
        string RemoveLabel(int labelId);
        string EditLabel(LabelModel labelModel);
    }
}
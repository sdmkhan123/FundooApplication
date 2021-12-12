using FundooModels;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace FundooRepository.Interface
{
    public interface ILabelRepository
    {
        IConfiguration Configuration { get; }
        string AddLabel(LabelModel labelModel);
        string DeleteLabel(int userId, string labelName);
        string RemoveLabel(int labelId);
        string EditLabel(LabelModel labelModel, string labelName);
        IEnumerable<string> GetLabelByUserId(int userId);
        IEnumerable<LabelModel> GetLabelByNoteId(int notesId);
    }
}
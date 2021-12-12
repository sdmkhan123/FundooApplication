using FundooModels;
using System.Collections.Generic;

namespace FundooManager.Interface
{
    public interface ILabelManager
    {
        string AddLabel(LabelModel labelModel);
        string DeleteLabel(int userId, string labelName);
        string RemoveLabel(int labelId);
        string EditLabel(LabelModel labelModel, string labelName);
        IEnumerable<string> GetLabelByUserId(int userId);
        IEnumerable<LabelModel> GetLabelByNoteId(int notesId);
    }
}
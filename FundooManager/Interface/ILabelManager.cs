using FundooModels;

namespace FundooManager.Interface
{
    public interface ILabelManager
    {
        string AddLabelByUserId(LabelModel labelModel);
        string AddLabelByNoteId(LabelModel labelModel);
        string DeleteLabel(int userId, string labelName);
    }
}
using FundooModels;

namespace FundooManager.Interface
{
    public interface INotesManager
    {
        string AddANote(NotesModel notesModel);
        string EditANote(NotesModel notesModel);
        string ChangeAColor(int noteId, string noteColor);
        string AddRemindMe(int notesId, string remindMeNotes);
        string DeleteRemindMe(int notesId);
        string DeleteANote(int notesId);
        string RestoreFromTrash(int notesId);
        string DeleteNoteForever(int notesId);
        string Archive(int noteId);
        string UnArchive(int noteId);
        string Pin(int notesId);
        string UnPin(int noteId);
    }
}
﻿using FundooModels;

namespace FundooManager.Interface
{
    public interface INotesManager
    {
        string AddANote(NotesModel notesModel);
        string EditANote(NotesModel notesModel);
        string ChangeAColor(int noteId, string noteColor);
        string AddRemindMe(int notesId, string remindMeNotes);
        string DeleteRemindMe(int notesId);
    }
}
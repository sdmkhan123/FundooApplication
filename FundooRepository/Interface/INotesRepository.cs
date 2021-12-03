﻿using FundooModels;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace FundooRepository.Interface
{
    public interface INotesRepository
    {
        IConfiguration Configuration { get; }
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
        IEnumerable<NotesModel> GetAllArchiveNotes(int userId);
        IEnumerable<NotesModel> GetAllReminderNotes(int userId);
        IEnumerable<NotesModel> GetAllTrashNotes(int userId);
    }
}
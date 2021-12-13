// ********************************************************************************
// <copyright file="INotesRepository.cs" company="Magic Soft">
//   Copyright © 2021 Company="Magic Soft"
// </copyright>
// <creator name="Saddam Khan"/>
// ********************************************************************************

namespace FundooRepository.Interface
{
    using System.Collections.Generic;
    using FundooModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Interface for INoteRepository
    /// </summary>
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

        IEnumerable<NotesModel> GetAllNotes(int userId);

        string AddImage(int noteId, IFormFile imagePath);
    }
}
using FundooManager.Interface;
using FundooModels;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class NotesManager : INotesManager
    {
        private readonly INotesRepository notesRepository;
        public NotesManager(INotesRepository notesRepository)
        {
            this.notesRepository = notesRepository;
        }
        public string AddANote(NotesModel notesModel)
        {
            try
            {
                return this.notesRepository.AddANote(notesModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string EditANote(NotesModel notesModel)
        {
            try
            {
                return this.notesRepository.EditANote(notesModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string ChangeAColor(int noteId, string noteColor)
        {
            try
            {
                return this.notesRepository.ChangeAColor(noteId, noteColor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string AddRemindMe(int notesId, string remindMeNotes)
        {
            try
            {
                return this.notesRepository.AddRemindMe(notesId, remindMeNotes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteRemindMe(int notesId)
        {
            try
            {
                return this.notesRepository.DeleteRemindMe(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteANote(int notesId)
        {
            try
            {
                return this.notesRepository.DeleteANote(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string RestoreFromTrash(int notesId)
        {
            try
            {
                return this.notesRepository.RestoreFromTrash(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteNoteForever(int notesId)
        {
            try
            {
                return this.notesRepository.DeleteNoteForever(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string Archive(int noteId)
        {
            try
            {
                return this.notesRepository.Archive(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UnArchive(int noteId)
        {
            try
            {
                return this.notesRepository.UnArchive(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string Pin(int notesId)
        {
            try
            {
                return this.notesRepository.Pin(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UnPin(int noteId)
        {
            try
            {
                return this.notesRepository.UnPin(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<NotesModel> GetAllArchiveNotes(int userId)
        {
            try
            {
                return this.notesRepository.GetAllArchiveNotes(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<NotesModel> GetAllReminderNotes(int userId)
        {
            try
            {
                return this.notesRepository.GetAllReminderNotes(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<NotesModel> GetAllTrashNotes(int userId)
        {
            try
            {
                return this.notesRepository.GetAllTrashNotes(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<NotesModel> GetAllNotes(int userId)
        {
            try
            {
                return this.notesRepository.GetAllNotes(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
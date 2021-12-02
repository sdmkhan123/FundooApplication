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
    }
}
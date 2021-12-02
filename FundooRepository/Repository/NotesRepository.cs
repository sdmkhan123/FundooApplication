using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundooRepository.Repository
{
    public class NotesRepository : INotesRepository
    {
        private readonly UserContext userContext;
        public IConfiguration Configuration { get; }
        public NotesRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }
        public string AddANote(NotesModel notesModel)
        {
            try
            {
                if (notesModel != null)
                {
                    this.userContext.Notes.Add(notesModel);
                    this.userContext.SaveChanges();
                    return "New note Added successfully";
                }
                else
                {
                    return "Note creation is unsuccesful";
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string EditANote(NotesModel notesModel)
        {
            try
            {
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == notesModel.NoteId).FirstOrDefault();
                if (validNoteId != null)
                {
                    if (notesModel != null)
                    {
                        validNoteId.Title = notesModel.Title;
                        validNoteId.TakeANotes = notesModel.TakeANotes;
                        this.userContext.Notes.Update(validNoteId);
                        this.userContext.SaveChanges();
                        return "Note is Edited successfully";
                    }
                    else
                    {
                        return "Note Edited is unsuccessful";
                    }
                }
                else
                {
                    return "This note does not exist. Kindly create a new one";
                }
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
                var validNote = this.userContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (validNote != null)
                {
                    validNote.ChangeColor = noteColor;
                    this.userContext.Notes.Update(validNote);
                    this.userContext.SaveChanges();
                    return "Color is changed successfully";
                }
                return "Color update is unsuccessful";
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
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == notesId).SingleOrDefault();
                if (validNoteId != null)
                {
                    validNoteId.RemindeMe = remindMeNotes;
                    this.userContext.Notes.Update(validNoteId);
                    this.userContext.SaveChanges();
                    return "Reminder added successfully";
                }
                else
                {
                    return "This note does not exist. Kindly create a new one.";
                }
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
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == notesId).SingleOrDefault();
                if (validNoteId != null)
                {
                    validNoteId.RemindeMe = null;
                    this.userContext.Notes.Update(validNoteId);
                    this.userContext.SaveChanges();
                    return "Reminder deleted successfully";
                }
                return "This Reminder does not exist. Kindly create a new one";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteANote(int notesId)
        {
            try
            {
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == notesId).FirstOrDefault();
                if (validNoteId != null)
                {
                    validNoteId.Trash = true;
                    validNoteId.Archive = false;
                    if (validNoteId.PinNote == true)
                    {
                        validNoteId.PinNote = false;
                        this.userContext.Notes.Update(validNoteId);
                        this.userContext.SaveChanges();
                        return "Note unpinned and trashed sucessfully";
                    }
                    this.userContext.Notes.Update(validNoteId);
                    this.userContext.SaveChanges();
                    return "Note trashed successfully";
                }
                else
                {
                    return "This note does not exist. Kindly create a new one";
                }
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
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == notesId).FirstOrDefault();
                if (validNoteId != null)
                {
                    validNoteId.Trash = false;
                    this.userContext.Notes.Update(validNoteId);
                    this.userContext.SaveChangesAsync();
                    return "Note restored from Trash successfully";
                }
                else
                {
                    return "This note does not exist in Trash";
                }
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
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == notesId).FirstOrDefault();
                if (validNoteId != null)
                {
                    this.userContext.Notes.Remove(validNoteId);
                    this.userContext.SaveChanges();
                    return "This note is deleted forever";
                }
                else
                {
                    return "This note does not exist in Trash.";
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string Archive(int noteId)
        {
            try
            {
                var validNote = this.userContext.Notes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (validNote != null && validNote.Trash != true)
                {
                    validNote.Archive = true;
                    if (validNote.PinNote == true)
                    {
                        validNote.PinNote = false;
                        this.userContext.Notes.Update(validNote);
                        this.userContext.SaveChanges();
                        return "Note is unpinned and archived successfully";
                    }
                    this.userContext.Notes.Update(validNote);
                    this.userContext.SaveChanges();
                    return "Note is archived successfully";
                }
                else
                {
                    return "This note does not exist";
                }
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
                var validNote = this.userContext.Notes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (validNote != null && validNote.Archive != false)
                {
                    validNote.Archive = false;
                    this.userContext.Notes.Update(validNote);
                    this.userContext.SaveChangesAsync();
                    return "Note is UnArchive successfully";
                }
                else
                {
                    return "This note does not exist in Archive";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
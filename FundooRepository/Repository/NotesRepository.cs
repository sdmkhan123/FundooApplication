// ********************************************************************************
// <copyright file="NotesRepository.cs" company="Magic Soft">
//   Copyright © 2021 Company="Magic Soft"
// </copyright>
// <creator name="Saddam Khan"/>
// ********************************************************************************

namespace FundooRepository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using FundooModels;
    using FundooRepository.Context;
    using FundooRepository.Interface;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Class for NoteRepository with all Note functionalities
    /// </summary>
    public class NotesRepository : INotesRepository
    {
        /// <summary>
        /// User Context Objects
        /// </summary>
        private readonly UserContext userContext;

        public NotesRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }

        public IConfiguration Configuration { get; }

        public string AddANote(NotesModel notesModel)
        {
            try
            {
                this.userContext.Notes.Add(notesModel);
                this.userContext.SaveChanges();
                return "New note Added successfully";
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

        public string AddImage(int noteId, IFormFile imagePath)
        {
            try
            {
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (validNoteId != null)
                {
                    var cloudinary = new Cloudinary(
                                                new Account(
                                                "dbk4dugg0",
                                                "283758771257289",
                                                "tu2T1d7CmeMsdYyL9Qf1Y8k5UxI"));

                    var uploadImage = new ImageUploadParams()
                    {
                        File = new FileDescription(imagePath.FileName, imagePath.OpenReadStream())
                    };
                    var uploadResult = cloudinary.Upload(uploadImage);
                    var uploadPath = uploadResult.Url;
                    validNoteId.AddImage = uploadPath.ToString();
                    this.userContext.SaveChanges();
                    return "Image Added successfully";
                }
                else
                {
                    return "Note does not Exist";
                }
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
                string showMessage;
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == notesId).FirstOrDefault();
                if (validNoteId != null)
                {
                    validNoteId.Trash = true;
                    validNoteId.Archive = false;
                    if (validNoteId.PinNote == true)
                    {
                        validNoteId.PinNote = false;
                        showMessage = "Note unpinned and trashed sucessfully";
                    }

                    showMessage = "Note trashed successfully";
                }
                else
                {
                    showMessage = "This note does not exist. Kindly create a new one";
                }

                this.userContext.Notes.Update(validNoteId);
                this.userContext.SaveChanges();
                return showMessage;
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
                string showMessage;
                var validNote = this.userContext.Notes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (validNote != null && validNote.Trash != true)
                {
                    validNote.Archive = true;
                    if (validNote.PinNote == true)
                    {
                        validNote.PinNote = false;
                        showMessage = "Note is unpinned and archived successfully";
                    }

                    showMessage = "Note is archived successfully";
                }
                else
                {
                    showMessage = "This note does not exist";
                }

                this.userContext.Notes.Update(validNote);
                this.userContext.SaveChanges();
                return showMessage;
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

        public string Pin(int notesId)
        {
            try
            {
                string showMessage;
                var valiNoteId = this.userContext.Notes.Where(x => x.NoteId == notesId).FirstOrDefault();
                if (valiNoteId != null && valiNoteId.Trash != true)
                {
                    valiNoteId.PinNote = true;
                    if (valiNoteId.Archive == true)
                    {
                        valiNoteId.Archive = false;
                        showMessage = "Note unarchived and pinned successfully";
                    }
                    else
                    {
                        showMessage = "Note pinned successfully";
                    }
                }
                else
                {
                    showMessage = "This note does not exist";
                }

                this.userContext.Notes.Update(valiNoteId);
                this.userContext.SaveChanges();
                return showMessage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string UnPin(int notesId)
        {
            try
            {
                var validNote = this.userContext.Notes.Where(x => x.NoteId == notesId).SingleOrDefault();
                if (validNote != null && validNote.PinNote != false)
                {
                    validNote.PinNote = false;
                    this.userContext.Notes.Update(validNote);
                    this.userContext.SaveChangesAsync();
                    return "Note is UnPin successfully";
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

        public IEnumerable<NotesModel> GetAllArchiveNotes(int userId)
        {
            try
            {
                IEnumerable<NotesModel> validUserId = this.userContext.Notes.Where(x => x.UserId == userId && x.Archive == true);
                if (validUserId != null)
                {
                    return validUserId;
                }

                return null;
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
                IEnumerable<NotesModel> validReminder = this.userContext.Notes.Where(x => x.UserId == userId && x.RemindeMe != null);
                if (validReminder != null)
                {
                    return validReminder;
                }

                return null;
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
                IEnumerable<NotesModel> validTrashedNotes = this.userContext.Notes.Where(x => (x.UserId == userId && x.Trash == true));
                if (validTrashedNotes != null)
                {
                    return validTrashedNotes;
                }

                return null;
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
                IEnumerable<NotesModel> dataFromAllNotes = from notes in this.userContext.Notes where notes.UserId == userId && notes.Archive == false && notes.Trash == false select notes;
                if (dataFromAllNotes != null)
                {
                    return dataFromAllNotes;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
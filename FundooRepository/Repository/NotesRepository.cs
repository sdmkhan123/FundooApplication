﻿using FundooModels;
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
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesController.cs" company="Magic Soft">
//   Copyright © 2021 Company="Magic Soft"
// </copyright>
// <creator name="Saddam Khan"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooNotes.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FundooManager.Interface;
    using FundooModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Notes controller class for API related to Notes
    /// </summary>
    ////[Authorize]
    public class NotesController : ControllerBase
    {
        /// <summary>
        /// Declaring a object for note manager
        /// </summary>
        private readonly INotesManager notesManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController"/> class
        /// </summary>
        /// <param name="notesManager">passing a notes manager as parameter of type INotesManager</param>
        public NotesController(INotesManager notesManager)
        {
            this.notesManager = notesManager;
        }

        /// <summary>
        /// Implemented AddNote API
        /// </summary>
        /// <param name="notesModel">passing notesModel as parameter of type NotesModel</param>
        /// <returns>Returns a IAction Result</returns>
        [HttpPost]
        [Route("api/addanote")]
        public IActionResult AddANote([FromBody] NotesModel notesModel)
        {
            try
            {
                string result = this.notesManager.AddANote(notesModel);
                if (result == "New note Added successfully")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Implemented EditANote API
        /// </summary>
        /// <param name="notesModel">passing notesModel as parameter of type NotesModel</param>
        /// <returns>Returns a IAction Result</returns>
        [HttpPut]
        [Route("api/editanote")]
        public IActionResult EditANote([FromBody] NotesModel notesModel)
        {
            try
            {
                string result = this.notesManager.EditANote(notesModel);
                if (result.Equals("Note is Edited successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Implemented AddImage API
        /// </summary>
        /// <param name="noteId">passing noteId as parameter of type INT</param>
        /// <param name="imagePath">passing imagePath as parameter of type IFormFile</param>
        /// <returns>Returns a IAction Result</returns>
        [HttpPut]
        [Route("api/addimage")]
        public IActionResult AddImage(int noteId, IFormFile imagePath)
        {
            try
            {
                string result = this.notesManager.AddImage(noteId, imagePath);
                if (result.Equals("Image Added successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = true, Message = ex.Message });
            }
        }

        /// <summary>
        /// Implemented ChangeAColor API
        /// </summary>
        /// <param name="noteId">passing noteId as parameter of type INT</param>
        /// <param name="noteColor">passing noteColor as parameter of type string</param>
        /// <returns>Returns a IAction Result</returns>
        [HttpPut]
        [Route("api/changeacolor")]
        public IActionResult ChangeAColor(int noteId, string noteColor)
        {
            try
            {
                string result = this.notesManager.ChangeAColor(noteId, noteColor);
                if (result.Equals("Color is changed successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Implemented AddRemindMe API
        /// </summary>
        /// <param name="notesId">passing noteId as parameter of type INT</param>
        /// <param name="remindMeNotes">passing remindMeNotes as parameter of type string</param>
        /// <returns>Returns a IAction Result</returns>
        [HttpPut]
        [Route("api/addremindme")]
        public IActionResult AddRemindMe(int notesId, string remindMeNotes)
        {
            try
            {
                string result = this.notesManager.AddRemindMe(notesId, remindMeNotes);
                if (result.Equals("Reminder added successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Implemented DeleteRemindMe API
        /// </summary>
        /// <param name="notesId">passing noteId as parameter of type INT</param>
        /// <returns>Returns a IAction Result</returns>
        [HttpPut]
        [Route("api/deletermideme")]
        public IActionResult DeleteRemindMe(int notesId)
        {
            try
            {
                string result = this.notesManager.DeleteRemindMe(notesId);
                if (result.Equals("Reminder deleted successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Implemented DeleteANote API
        /// </summary>
        /// <param name="notesId">passing noteId as parameter of type INT</param>
        /// <returns>Returns a IAction Result</returns>
        [HttpPut]
        [Route("api/deleteanote")]
        public IActionResult DeleteANote(int notesId)
        {
            try
            {
                string result = this.notesManager.DeleteANote(notesId);
                if (result.Equals("This note does not exist. Kindly create a new one"))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
                else
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Implemented RestoreFromTrash API
        /// </summary>
        /// <param name="notesId">passing noteId as parameter of type INT</param>
        /// <returns>Returns a IAction Result</returns>
        [HttpPut]
        [Route("api/restorefromtrash")]
        public IActionResult RestoreFromTrash(int notesId)
        {
            try
            {
                string result = this.notesManager.RestoreFromTrash(notesId);
                if (result.Equals("Note restored from Trash successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Implemented DeleteNoteForever API
        /// </summary>
        /// <param name="notesId">passing noteId as parameter of type INT</param>
        /// <returns>Returns a IAction Result</returns>
        [HttpDelete]
        [Route("api/deletenoteforever")]
        public IActionResult DeleteNoteForever(int notesId)
        {
            try
            {
                string result = this.notesManager.DeleteNoteForever(notesId);
                if (result.Equals("This note is deleted forever"))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.Ok(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Implemented Archive API
        /// </summary>
        /// <param name="noteId">passing noteId as parameter of type INT</param>
        /// <returns>Returns a IAction Result</returns>
        [HttpPut]
        [Route("api/archive")]
        public IActionResult Archive(int noteId)
        {
            try
            {
                string result = this.notesManager.Archive(noteId);
                if (result.Equals("This note does not exist"))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
                else
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Implemented UnArchive API
        /// </summary>
        /// <param name="noteId">passing noteId as parameter of type INT</param>
        /// <returns>Returns a IAction Result</returns>
        [HttpPut]
        [Route("api/unarchive")]
        public IActionResult UnArchive(int noteId)
        {
            try
            {
                string result = this.notesManager.UnArchive(noteId);
                if (result.Equals("Note is UnArchive successfully"))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.Ok(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Implemented Pin API
        /// </summary>
        /// <param name="notesId">passing noteId as parameter of type INT</param>
        /// <returns>Returns a IAction Result</returns>
        [HttpPut]
        [Route("api/pin")]
        public IActionResult Pin(int notesId)
        {
            try
            {
                string result = this.notesManager.Pin(notesId);
                if (result.Equals("This note does not exist"))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
                else
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Implemented UnPin API
        /// </summary>
        /// <param name="noteId">passing noteId as parameter of type INT</param>
        /// <returns>Returns a IAction Result</returns>
        [HttpPut]
        [Route("api/unpin")]
        public IActionResult UnPin(int noteId)
        {
            try
            {
                string result = this.notesManager.UnPin(noteId);
                if (result.Equals("Note is UnPin successfully"))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.Ok(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Implemented GetAllArchiveNotes API
        /// </summary>
        /// <param name="userId">passing userId as parameter of type INT</param>
        /// <returns>Returns a IAction Result</returns>
        [HttpGet]
        [Route("api/getallarchievednotes")]
        public IActionResult GetAllArchiveNotes(int userId)
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.GetAllArchiveNotes(userId);

                if (result.Equals(null))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "There are no Archive notes to be Get" });
                }
                else
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Get Archive Notes successfully", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Implemented GetAllReminderNotes API
        /// </summary>
        /// <param name="userId">passing userId as parameter of type INT</param>
        /// <returns>Returns a IAction Result</returns>
        [HttpGet]
        [Route("api/getallremindernotes")]
        public IActionResult GetAllReminderNotes(int userId)
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.GetAllReminderNotes(userId);

                if (result.Equals(null))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Thee is no Note Reminder created for this userId" });
                }
                else
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Get NoteReminder successfully", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Implemented GetAllTrashNotes API
        /// </summary>
        /// <param name="userId">passing userId as parameter of type INT</param>
        /// <returns>Returns a IAction Result</returns>
        [HttpGet]
        [Route("api/getalltrashnotes")]
        public IActionResult GetAllTrashNotes(int userId)
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.GetAllTrashNotes(userId);

                if (result.Equals(null))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "There is no Notes in Trash for this UserId" });
                }
                else
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Get Notes from the trash successfully", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Implemented GetAllNotes API
        /// </summary>
        /// <param name="userId">passing userId as parameter of type INT</param>
        /// <returns>Returns a IAction Result</returns>
        [HttpGet]
        [Route("api/getallnotes")]
        public IActionResult GetAllNotes(int userId)
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.GetAllNotes(userId);

                if (result.Equals(null))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "No note exists whose data is data is to be retrieved" });
                }
                else
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Data for all notes is retrived successfully", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }
    }
}
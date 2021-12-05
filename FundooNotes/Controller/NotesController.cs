using FundooManager.Interface;
using FundooModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controller
{
    public class NotesController : ControllerBase
    {
        private readonly INotesManager notesManager;

        public NotesController(INotesManager notesManager)
        {
            this.notesManager = notesManager;
        }
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
        [HttpGet]
        [Route("api/getallarchievednotes")]
        public IActionResult GetAllArchiveNotes(int userId)
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.GetAllArchiveNotes(userId);

                if (result.Equals(null))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = 
                        "There are no Archive notes to be Get" });
                }
                else
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = 
                        "Get Archive Notes successfully", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/getallremindernotes")]
        public IActionResult GetAllReminderNotes(int userId)
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.GetAllReminderNotes(userId);

                if (result.Equals(null))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = 
                        "Thee is no Note Reminder created for this userId" });
                }
                else
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = 
                        "Get NoteReminder successfully", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/getalltrashnotes")]
        public IActionResult GetAllTrashNotes(int userId)
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.GetAllTrashNotes(userId);

                if (result.Equals(null))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = 
                        "There is no Notes in Trash for this UserId" });
                }
                else
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = 
                        "Get Notes from the trash successfully", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/getallnotes")]
        public IActionResult GetAllNotes(int userId)
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.GetAllNotes(userId);

                if (result.Equals(null))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = 
                        "No note exists whose data is data is to be retrieved" });
                }
                else
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = 
                        "Data for all notes is retrived successfully", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }
    }
}
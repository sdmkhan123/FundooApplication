using FundooManager.Interface;
using FundooModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controller
{
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorManager collaboratorManager;

        public CollaboratorController(ICollaboratorManager manager)
        {
            this.collaboratorManager = manager;
        }
        [HttpPost]
        [Route("api/addcollaborator")]
        public IActionResult AddCollaborator([FromBody] CollaboratorModel collaboratorModel)
        {
            try
            {
                string result = this.collaboratorManager.AddCollaborator(collaboratorModel);
                if (result.Equals("Collaborator added successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, });
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
        [Route("api/deletecollaborator")]
        public IActionResult DeleteCollaborator(int collaboratorId)
        {
            try
            {
                string result = this.collaboratorManager.DeleteCollaborator(collaboratorId);
                if (result.Equals("Collaborator deleted successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, });
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

        [HttpGet]
        [Route("api/getcollaboratordetails")]
        public IActionResult GetCollaboratorDetails(int noteId)
        {
            try
            {
                var result = this.collaboratorManager.GetCollaboratorDetails(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<CollaboratorModel>>() { Status = true, 
                        Message = "Collaborator details fetched successfully", Data = result});
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, 
                        Message = "Collaborator details not found" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interface;
using Microsoft.Extensions.Configuration;

namespace FundooRepository.Repository
{
    public class LabelRepository : ILabelRepository
    {
        private readonly UserContext userContext;
        public IConfiguration Configuration { get; }
        public LabelRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }
        public string AddLabelByUserId(LabelModel labelModel)
        {
            try
            {
                var validLabel = this.userContext.Labels.Where(x => x.UserId == labelModel.UserId && x.LabelName != labelModel.LabelName && x.NoteId == null).FirstOrDefault();
                if (validLabel != null)
                {
                    this.userContext.Labels.Add(labelModel);
                    this.userContext.SaveChanges();
                    return "Label added successfully";
                }
                return "The label with this name already exists";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string AddLabelByNoteId(LabelModel labelModel)
        {
            try
            {
                var validLabel = this.userContext.Labels.Where(x => x.UserId == labelModel.UserId && x.NoteId == labelModel.NoteId).FirstOrDefault();
                if (validLabel != null)
                {
                    this.userContext.Labels.Add(labelModel);
                    this.userContext.SaveChanges();
                    return "Label added successfully";
                }
                return "The label with this name already exists";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteLabel(int userId, string labelName)
        {
            try
            {
                var validLabel = this.userContext.Labels.Where(x => x.LabelName == labelName && x.UserId == userId).ToList();
                if (validLabel != null)
                {
                    this.userContext.Labels.RemoveRange(validLabel);
                    this.userContext.SaveChanges();
                    return "Label deleted successfully";
                }
                return "Label not exist. Kindly create a new one";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string RemoveLabel(int labelId)
        {
            try
            {
                var validLabel = this.userContext.Labels.Where(x => x.LabelId == labelId).FirstOrDefault();
                if (validLabel != null)
                {
                    this.userContext.Labels.Remove(validLabel);
                    this.userContext.SaveChanges();
                    return "Label was deleted from the note successfully";
                }

                return "There is no label present with this name";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string EditLabel(LabelModel labelModel)
        {
            try
            {
                var validLabel = this.userContext.Labels.Where(x => x.LabelId == labelModel.LabelId).Select(x => x.LabelName).FirstOrDefault();
                var prevLabelname = this.userContext.Labels.Where(x => x.LabelName == validLabel).ToList();
                prevLabelname.ForEach(x => x.LabelName = labelModel.LabelName);
                this.userContext.Labels.UpdateRange(prevLabelname);
                this.userContext.SaveChanges();
                return "Label Edited successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<string> GetLabelByUserId(int userId)
        {
            try
            {
                IEnumerable<string> validLabel = this.userContext.Labels.Where(x => 
                x.UserId == userId).Select(x => x.LabelName);
                if (validLabel != null)
                {
                    return validLabel;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<LabelModel> GetLabelByNoteId(int notesId)
        {
            try
            {
                IEnumerable<LabelModel> validLabel = this.userContext.Labels.Where(x => x.NoteId == notesId);
                if (validLabel != null)
                {
                    return validLabel;
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
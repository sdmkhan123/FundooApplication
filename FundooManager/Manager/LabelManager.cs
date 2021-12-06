using FundooManager.Interface;
using FundooModels;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class LabelManager : ILabelManager
    {
        private readonly ILabelRepository labelRepository;
        public LabelManager(ILabelRepository labelRepository)
        {
            this.labelRepository = labelRepository;
        }
        public string AddLabelByUserId(LabelModel labelModel)
        {
            try
            {
                return this.labelRepository.AddLabelByUserId(labelModel);
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
                return this.labelRepository.AddLabelByNoteId(labelModel);
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
                return this.labelRepository.DeleteLabel(userId, labelName);
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
                return this.labelRepository.RemoveLabel(labelId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

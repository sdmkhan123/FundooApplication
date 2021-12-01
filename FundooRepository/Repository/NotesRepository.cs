using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModels
{
    public class CollaboratorModel
    {
        /// <summary>
        /// added CollaboratorId as a primary key
        /// </summary>
        [Key]
        public int CollaboratorId { get; set; }
        public int NoteId { get; set; }
        [ForeignKey("NoteId")]
        public NotesModel notesModel { get; set; }
        public string EmailId { get; set; }
    }
}

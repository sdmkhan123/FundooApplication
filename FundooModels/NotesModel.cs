using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModels
{
    public class NotesModel
    {
        [Key]
        public int NoteId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public RegisterModel registerModel { get; set; }
        public string Title { get; set; }
        public string TakeANotes { get; set; }
        public string RemindeMe { get; set; }
        public string ChangeColor { get; set; }
        public string AddImage { get; set; }
        [DefaultValue(false)]
        public bool PinNote { get; set; }
        [DefaultValue(false)]
        public bool Archive { get; set; }
        [DefaultValue(false)]
        public bool Trash { get; set; }
    }
}
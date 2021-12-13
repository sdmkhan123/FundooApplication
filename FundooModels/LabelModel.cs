// *************************************************************************
// <copyright file="LabelModel.cs" company="Magic Soft">
//   Copyright © 2021 Company="Magic Soft"
// </copyright>
// <creator name="Saddam Khan"/>
// *************************************************************************

namespace FundooModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class LabelModel
    {
        [Key]
        public int LabelId { get; set; }
        public int? NoteId { get; set; }
        [ForeignKey("NoteId")]
        public NotesModel NotesModel { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public RegisterModel registerModel { get; set; }
        [Required]
        public string LabelName { get; set; }
    }
}

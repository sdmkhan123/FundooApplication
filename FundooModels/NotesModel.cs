// *************************************************************************
// <copyright file="NotesModel.cs" company="Magic Soft">
//   Copyright © 2021 Company="Magic Soft"
// </copyright>
// <creator name="Saddam Khan"/>
// *************************************************************************

namespace FundooModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// Notes model class
    /// </summary>
    public class NotesModel
    {
        /// <summary>
        /// Gets or sets the note id(primary key) 
        /// </summary>
        [Key]
        public int NoteId { get; set; }

        /// <summary>
        /// Gets or sets the user id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user id as foreign key
        /// </summary>
        [ForeignKey("UserId")]
        public RegisterModel registerModel { get; set; }

        /// <summary>
        ///  Gets or sets the title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Notes
        /// </summary>
        public string TakeANotes { get; set; }

        /// <summary>
        /// Gets or sets the Remainder
        /// </summary>
        public string RemindeMe { get; set; }

        /// <summary>
        /// Gets or sets the Color for note
        /// </summary>
        public string ChangeColor { get; set; }

        /// <summary>
        /// Gets or sets the Image for note
        /// </summary>
        public string AddImage { get; set; }

        /// <summary>
        ///  Gets or sets a value indicating whether status as true or false
        /// </summary>
        [DefaultValue(false)]
        public bool PinNote { get; set; }

        /// <summary>
        ///  Gets or sets a value indicating whether status as true or false, taken default value as false only
        /// </summary>
        [DefaultValue(false)]
        public bool Archive { get; set; }

        /// <summary>
        ///  Gets or sets a value indicating whether status as true or false, taken default value as false only
        /// </summary>
        [DefaultValue(false)]
        public bool Trash { get; set; }
    }
}
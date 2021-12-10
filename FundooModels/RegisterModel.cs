// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterModel.cs" company="Magic Soft">
//   Copyright © 2021 Company="Magic Soft"
// </copyright>
// <creator name="Saddam Khan"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    /// <summary>
    /// register model class
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email id
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the user id as primary key
        /// </summary>
        [Key]
        public int UserID { get; set; }
    }
}

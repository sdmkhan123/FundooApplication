// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginModel.cs" company="Magic Soft">
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
    /// Login model class
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Gets or sets email and it is required field
        /// </summary>
        [Required]
        public string Email { get; set; }
        [Required]

        /// <summary>
        /// Gets or sets password and it is required field
        /// </summary>
        public string Password { get; set; }
    }
}
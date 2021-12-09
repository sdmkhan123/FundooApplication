// ************************************************************************************
// <copyright file="ResetPasswordModel.cs" company="Magic Soft">
//   Copyright © 2021 Company="Magic Soft"
// </copyright>
// <creator name="Saddam Khan"/>
// ************************************************************************************

namespace FundooModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Class for reset password model
    /// </summary>
    public class ResetPasswordModel
    {
        /// <summary>
        /// Gets or sets the email as string
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the new password as string
        /// </summary>
        [Required]
        public string NewPassword { get; set; }
    }
}
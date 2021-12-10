// ************************************************************************************
// <copyright file="ResponseModel.cs" company="Magic Soft">
//   Copyright © 2021 Company="Magic Soft"
// </copyright>
// <creator name="Saddam Khan"/>
// ************************************************************************************

namespace FundooModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Response model class
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    public class ResponseModel<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether status as true or false
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Gets or sets the message as string
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the data as generic type
        /// </summary>
        public T Data { get; set; }
    }
}

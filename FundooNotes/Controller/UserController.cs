// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="Magic Soft">
//   Copyright © 2021 Company="Magic Soft"
// </copyright>
// <creator name="Saddam Khan"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooNotes.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FundooManager.Interface;
    using FundooModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using StackExchange.Redis;

    /// <summary>
    /// This is the userController class
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Object created for IUserManager
        /// </summary>
        private readonly IUserManager manager;

        /// <summary>
        /// Object created for ILogger
        /// </summary>
        private readonly ILogger<UserController> logger;

        /// <summary>
        /// Initializes a new instance of the UserController class
        /// </summary>
        /// <param name="manager">It is an object of the IUserManager class</param>
        /// <param name="logger">It is an object of the ILogger class</param>
        public UserController(IUserManager manager, ILogger<UserController> logger)
        {
            this.manager = manager;
            this.logger = logger;
        }

        /// <summary>
        /// Implemented Register API
        /// </summary>
        /// <param name="registerModel">It is an object of the of RegisterModel class</param>
        /// <returns>This methods returns IActionResult for User Registration</returns>
        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody] RegisterModel registerModel)
        {
            try
            {
                string result = this.manager.Register(registerModel);
                this.logger.LogInformation("New user added successfully with Firstname:" + registerModel.FirstName);
                if (result.Equals("Registration Successful!"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogWarning("Exception caught while registering new user:" + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Implemented Login API
        /// </summary>
        /// <param name="loginModel">It is an object of the of LoginModel class</param>
        /// <returns>This methods returns IActionResult for User Login</returns>
        [HttpPost]
        [Route("api/Login")]
        public IActionResult LogIn([FromBody] LoginModel loginModel)
        {
            try
            {
                string result = this.manager.LogIn(loginModel);

                if (result.Equals("Login Successful "))
                {
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    string firstName = database.StringGet("Firstname");
                    string lastName = database.StringGet("Lastname");
                    return this.Ok(new { Status = true, Message = result, firstName = firstName, lastName = lastName, Token = this.manager.JwtToken(loginModel.Email) });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Implemented reset Password API
        /// </summary>
        /// <param name="resetPasswordModel">It is an object of the ResetPasswordModel</param>
        /// <returns>return the IActionResult</returns>
        [HttpPut]
        [Route("api/resetpassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordModel resetPasswordModel)
        {
            try
            {
                string result = this.manager.ResetPassword(resetPasswordModel);
                if (result.Equals("Password is updated"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Implemented forget password API
        /// </summary>
        /// <param name="emailId">It is parameter passing to function</param>
        /// <returns>return the IActionResult</returns>
        [HttpPost]
        [Route("api/forgetpassword")]
        public IActionResult ForgotPassword(string emailId)
        {
            try
            {
                string result = this.manager.ForgotPassword(emailId);

                if (result.Equals("Email is sent sucessfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}

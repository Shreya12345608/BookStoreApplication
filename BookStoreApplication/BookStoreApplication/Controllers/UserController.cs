using BookStoreBussiness.BookStoreBussiness;
using BookStoreBussiness.IBookStoreBussiness;
using BookStoreModel.AccountModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //instance variable of BL
        public IUserAccountBL userAccountBL;
        //constructor of bookStoreController
        public UserController(IUserAccountBL userAccountBL)
        {
            this.userAccountBL = userAccountBL;
        }


        /// <summary>
        /// This method is created for user registration.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        public ActionResult AddUserDetails(Registration user)
        {
            string message;
            var result = this.userAccountBL.AddUserDetails(user);
            try
            {
                if (!result.Equals(null))
                {
                    message = "Successfully added user details in database.";
                    return this.Ok(new { Success = true, message, result });
                }
                message = "Please give proper user details and try again!!";
                return BadRequest(new { Success = true, message, result });
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().GetType() == typeof(SqlException))
                {
                    Int32 ErrorCode = ((SqlException)ex.InnerException).Number;
                    switch (ErrorCode)
                    {
                        case 2627:  // Unique constraint error
                            return this.BadRequest(new { Success = false, Message = " Unique constraint error", StackTrace = ex.StackTrace });

                        case 547:   // Constraint check violation
                            return this.BadRequest(new { Success = false, Message = " Constraint check violation", StackTrace = ex.StackTrace });

                        case 2601:  // Duplicated key row error
                            return this.BadRequest(new { Success = false, Message = " Duplicated Email ID. Please enter Unique Email IDow ", StackTrace = ex.StackTrace });
                        default:
                            break;
                    }
                }
                return this.BadRequest(new { Success = false, Message = ex.Message, StackTrace = ex.StackTrace });
            }
        }
        /// <summary>
        /// This method  is created for user login.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UserLogin")]
        public IActionResult Login(UserLogin login)
        {
            string message;

            try
            {
                var result = this.userAccountBL.Login(login);
                if (result != 0)
                {

                  //  string Token = userAccountBL.CreateToken(login.userEmail, result);
                    message = "Login done successfully.";
                    return this.Ok(new { message, login.userEmail, });
                }
                message = "Please check email and password and try again!!";
                return BadRequest(new { message });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, Message = ex.Message, StackTrace = ex.StackTrace });
            }
        }

        /// <summary>
        /// Controller method for Forget Password
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpPost]
        [Route("forget-Password")]
        public ActionResult ForgotPassword(ForgetPassword user)
        {
            try
            {
                string message;
                bool forgetpass = userAccountBL.ForgotPassword(user.userEmail);


                if (forgetpass)
                {
                    message = "Link has sent to the given email address to reset the password";
                    return Ok(new { Success = true, message });

                }
                message = "Unable to sent link to given email address.This Email doesn't exist in database.";
                return NotFound(new { Sucess = false, message });
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { Success = false, Message = ex.Message, StackTrace = ex.StackTrace });
            }

        }
    }
}
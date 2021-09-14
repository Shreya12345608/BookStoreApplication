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
                if (result != null)
                {
                   
                    string Token = userAccountBL.CreateToken(result.userEmail, result.Userid, result.roleName);
                    message = "Login done successfully.";
                    return this.Ok(new { message, login.userEmail, Token });
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
        /// <summary>
        /// Controller method for Reset Password
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        [HttpPut]
        [Route("reset-password")]
        public ActionResult ResetPassword( ResetPassword resetPassword)
        {

            try
            {

                ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
                int userId = Convert.ToInt32(principal.Claims.SingleOrDefault(c => c.Type == "userId").Value);
               // int userId = 0;
                bool resetPaswrd = userAccountBL.ResetPassword(resetPassword, userId);
                if (resetPaswrd)
                {
                    return Ok(new { Success = true, message = "Password Reset Successfull !" });
                }
                return NotFound(new { Sucess = false, message = "Failed to Reset Password. Given Email doesn't exist in database." });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message, StackTrace = ex.StackTrace });
            }

        }
    }
}
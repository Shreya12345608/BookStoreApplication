using BookStoreBussiness.BookStoreBussiness;
using BookStoreBussiness.IBookStoreBussiness;
using BookStoreModel.AccountModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var result = this.userAccountBL.Login(login);
            try
            {
                if (result != null)
                {
                    message = "Login done successfully.";
                    return this.Ok(new { message, result, });
                }
                message = "Please check email and password and try again!!";
                return BadRequest(new { message });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, Message = ex.Message, StackTrace = ex.StackTrace });
            }
        }

    }
}
using BookStoreBussiness.IBookStoreBussiness;
using BookStoreModel.AccountModel;
using BookStoreModel.AdminModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserAccountBL userAccountBL;
        private readonly IAdminBL adminBL;
        public AdminController(IAdminBL adminBL, IUserAccountBL userAccountBL)
        {
            this.adminBL = adminBL;
            this.userAccountBL = userAccountBL;
        }
        //[HttpPost]
        //public IActionResult RegisterAdmin(Admin admiUser)
        //{
        //    string message;
        //    try
        //    {
        //        var userResponse = adminBL.RegisterAdmin(admiUser);
        //        if (userResponse)
        //        {
        //            message = "Admin Registration Successfully  Done";
        //            return Ok(new { Success = true, message});
        //        }

        //        message = "Registration Failed, User Already Exists.Please Check Email";

        //        return Ok(new { Success = false, message });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { Success = false, Message = ex.Message });
        //    }
        //}

        [HttpPost]
        public IActionResult Login(UserLogin login)
        {
            string message;

            try
            {
                var result = this.adminBL.Login(login);
                if (result != null)
                {

                    string Token = userAccountBL.CreateToken(result.userEmail, result.Adminid, result.roleName);
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

    }
}

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
        //            return Ok(new { Success = false, message, data = userResponse });
        //        }

        //        message = "Registration Failed, User Already Exists.Please Check Email";

        //        return Ok(new { Success = false, message});
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { Success = false, Message = ex.Message });
        //    }
        //}

        //[HttpPost("Login")]
        //public ActionResult LoginUser(UserLogin userData)
        //{
        //    try
        //    {
        //        var user = userAccountBL.Login(userData);
        //        if (user != null)
        //        {
        //            //string token = userAccountBL.CreateToken(user.userEmail, user.Userid, user.Role);
        //            return Ok(new { Success = false, Message = "Login Successfull", data = user });
        //        }
        //        return Ok(new { Success = false, Message = "Login Failed" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { Success = false, Message = ex.Message });
        //    }
        //}

    }
}

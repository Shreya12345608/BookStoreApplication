using BookStoreBussiness.IBookStoreBussiness;
using BookStoreModel.AddressModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        public IAddressBL addressBL;


        public AddressController(IAddressBL addressBL)
        {
            this.addressBL = addressBL;
        }
        [HttpPost]

        public ActionResult AddNewAddress(AddressModel address)
        {
            string Message;
            try
            {
                ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
                int userId = Convert.ToInt32(principal.Claims.SingleOrDefault(c => c.Type == "userId").Value);

                var response = this.addressBL.AddNewAddress(userId, address);
                if (response)
                {
                    Message = "Address Added Successfully";
                    return this.Ok(new { Status = true, Message, Data = response });
                }
                Message = "Address Not added";
                return this.BadRequest(new { Status = false, Message, Data = response });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, Message = ex.Message, StackTrace = ex.StackTrace });
            }
        }

       
        private int GetUserIDFromToken()
        {
            return Convert.ToInt32(User.FindFirst(user => user.Type == "userId").Value);
        }
        [HttpGet]
        [Route("addressList")]
        public ActionResult AllAddress(int userId)
        {
            int useeId = GetUserIDFromToken();
            string Message;
            try
            {
                //  ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
                //int userIds = Convert.ToInt32(principal.Claims.SingleOrDefault(c => c.Type == "userId").Value);
                List<AddressModel> result = this.addressBL.GetAllAddress(useeId);
                if (result != null)
                {
                    Message = "List Of Address Of userId  " + useeId;
                    return this.Ok(new { Status = true, Message, Data = result });
                }
                Message = "You dont have any address add new address for  " + useeId;
                return this.BadRequest(new { Status = false, Message, Data = result });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = "Exception", Data = e });
            }
        }
    }

}

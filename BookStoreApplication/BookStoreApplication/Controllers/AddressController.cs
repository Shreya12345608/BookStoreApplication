using BookStoreBussiness.IBookStoreBussiness;
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
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        public IAddressBL addressBL;


        public AddressController(IAddressBL addressBL)
        {
            this.addressBL = addressBL;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]

        public ActionResult AddNewAddress(string address)
        {
            int userID = this.getUserId();
            string Message;
            try
            {
                var response = this.addressBL.AddNewAddress(userID, address);
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

        private int getUserId()
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            int userId = Convert.ToInt32(principal.Claims.SingleOrDefault(c => c.Type == "userId").Value);
            return userId;
        }
    }

}

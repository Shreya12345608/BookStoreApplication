using BookStoreBussiness.IBookStoreBussiness;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public IOrderBL orderBL;

        public OrderController(IOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }

        private int GetUserID()
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            int userId = Convert.ToInt32(principal.Claims.SingleOrDefault(c => c.Type == "userId").Value);
            return userId;
        }

        //[HttpPost]
        //[Route("placeOrder")]
        //public ActionResult PlaceOrder()
        //{
        //    int userID = this.GetUserID();
        //    try
        //    {
        //        string Message;
        //        Task<string> response = this.orderBL.PlaceOrder(userID);

        //        if (response.Result != null)
        //        {
        //            Message = "order placed Successfully";
        //            return this.Ok(new { Status = true, Message, Data = response.Result });
        //        }
        //        Message = "Order not placed";
        //        return this.BadRequest(new { Status = false,Message, Data = response.Result });
        //    }
        //    catch (Exception e)
        //    {
        //        return this.BadRequest(new { Status = false, Message = "Exception", Data = e });
        //    }
        //}
    }
}

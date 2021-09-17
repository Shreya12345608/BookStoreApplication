using BookStoreBussiness.IBookStoreBussiness;
using BookStoreModel.CartModel;
using BookStoreModel.OrderModel;
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

        /// <summary>
        /// This method is deleting cart details by taking cart Id.
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult PlaceOrder()
        {
            string Message;
            try
            {
                int userId = this.GetUserID();
               
                
                bool result = orderBL.PlaceOrder(userId);
                if (result)
                {
                    Message = $"hurray!!! your order is confirmed the order id is #{userId} save the order id for further communication..";
                    return this.Ok(new { Status = true, Message, Data = result });
                }
                Message = "Order not placed";
                return this.BadRequest(new { Status = false, Message, Data = result });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = "Exception", Data = e });
            }
        }
    }
}




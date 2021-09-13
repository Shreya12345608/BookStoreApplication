using BookStoreBussiness.IBookStoreBussiness;
using BookStoreModel.AccountModel;
using BookStoreModel.CartModel;
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
    public class CartController : ControllerBase
    {
        public ICartBL cartBL;

        public CartController(ICartBL cartBL)
        {
            this.cartBL = cartBL;
        }
        /// <summary>
        /// This method is adding cart details.
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddCartDetails(CartModel cart)
        {
            string message;
            int userID = getIdFromToken();
            var result = this.cartBL.AddCartDetails(cart, userID);
            try
            {
                if (!result.Equals(null))
                {
                    message = "Successfully added cart details in database.";
                    return this.Ok(new { message, result });
                }
                message = "Please given correct cart details and try again....!!";
                return BadRequest(new { message });
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { Success = false, Message = ex.Message, StackTrace = ex.StackTrace });
            }
        }
      

        private int getIdFromToken()
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            int userId = Convert.ToInt32(principal.Claims.SingleOrDefault(c => c.Type == "userId").Value);
            return userId;
        }

        /// <summary>
        /// This method is getting books details from cart.
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllBooksFromCart(int userId)
        {
            int userID = getIdFromToken();

            string message;
            var result = this.cartBL.GetAllBooksFromCart(userID);
            try
            {
                if (!result.Equals(null))
                {
                    message = "Successfully shown all book details  in cart of given userId.";
                    return this.Ok(new { message, result });
                }
                message = "Please enter correct email,and retry!!";
                return BadRequest(new { message });
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { Success = false, Message = ex.Message, StackTrace = ex.StackTrace });
            }
        }


        /// <summary>
        /// This method is deleting cart details by taking cart Id.
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{bookId}")]
        public IActionResult DeleteCart(int bookId)
        {
            string message;
            try
            {
                int userId = this.getIdFromToken();
                cartRequest cart = new cartRequest
                {
                    BookId = bookId,
                    userId = userId
                };
                bool result = cartBL.DeleteCart(cart);
                if (result)
                {
                    message = "Successfully deleted cart details";
                    return this.Ok(new { message });
                }
                message = "Cart id is not match with our database.Please give correct bookId.";
                return BadRequest(new { message });
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { Success = false, Message = ex.Message, StackTrace = ex.StackTrace });
            }
        }
      

    }
}

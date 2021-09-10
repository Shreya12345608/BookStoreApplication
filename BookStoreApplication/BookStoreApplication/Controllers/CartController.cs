using BookStoreBussiness.IBookStoreBussiness;
using BookStoreModel.CartModel;
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
            var result = this.cartBL.AddCartDetails(cart);
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
        /// <summary>
        /// This method is getting books details from cart.
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllBooksFromCart(string Email)
        {
            string message;
            var result = this.cartBL.GetAllBooksFromCart(Email);
            try
            {
                if (!result.Equals(null))
                {
                    message = "Successfully shown all book details  in cart of given email.";
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
        public IActionResult DeleteCartDetailsByCartId(int cartId)
        {
            string message;
            try
            {
                if (this.cartBL.DeleteCartDetailsByCartId(cartId))
                {
                    message = "Successfully deleted cart deatils of given cartId";
                    return this.Ok(new { message });
                }
                message = "Cart id is not match with our database.Please give correct CartId.";
                return BadRequest(new { message });
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { Success = false, Message = ex.Message, StackTrace = ex.StackTrace });
            }
        }
    }
}

using BookStoreBussiness.IBookStoreBussiness;
using BookStoreModel.CartModel;
using BookStoreRepository.IBookStoreRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBussiness.BookStoreBussiness
{
   public class CartBL : ICartBL
    {
        private readonly ICartRL cartRL;

        public CartBL(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }
        /// <summary>
        /// Add to cart details
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public object AddCartDetails(CartModel cart)
        {
            return this.cartRL.AddCartDetails(cart);
        }

        /// <summary>
        /// Delete cart 
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public bool DeleteCart(cartRequest cart)
        {
            return this.cartRL.DeleteCart(cart);
        }

        /// <summary>
        /// get all book from cart
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public List<CartModel> GetAllBooksFromCart(int userId)
        {
            return this.cartRL.GetAllBooksFromCart(userId);
        }
    }
}


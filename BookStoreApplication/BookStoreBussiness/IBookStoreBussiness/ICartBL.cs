using BookStoreModel.CartModel;
using BookStoreRepository.IBookStoreRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBussiness.IBookStoreBussiness
{
    public interface ICartBL
    {
        /// <summary>
        /// This is aading cart details method.
        /// </summary>
        /// <param name="cartModel"></param>
        /// <returns></returns>
        public object AddCartDetails(CartModel cart);

        /// <summary>
        /// This is deleting cart details method 
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
       public bool DeleteCart(cartRequest cart);

        /// <summary>
        /// This is getting all  book details from cart method.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<CartModel> GetAllBooksFromCart(int userId);
    }
}


using BookStoreModel.CartModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepository.IBookStoreRepository
{
    public interface ICartRL
    {
        /// <summary>
        /// This is aading cart details method.
        /// </summary>
        /// <param name="cartModel"></param>
        /// <returns></returns>
        object AddCartDetails(CartModel cartModel);

        /// <summary>
        /// This is deleting cart details method by taking cart id.
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        bool DeleteCartByCartId(cartRequest cart);

        /// <summary>
        /// This is getting all  book details from cart method.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        List<CartModel> GetAllBooksFromCart(string userEmail);

    }
}

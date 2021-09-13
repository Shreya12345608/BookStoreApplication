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
        object AddCartDetails(CartModel cartModel,int userId);

        /// <summary>
        /// This is deleting cart details method by taking cart id.
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        bool DeleteCart(cartRequest cart);

        /// <summary>
        /// This is getting all  book details from cart method.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<CartModel> GetAllBooksFromCart(int userId);
        /// <summary>
        /// decrease from cart
        /// </summary>
        /// <param name="cartModel"></param>
        /// <returns></returns>
        public object decreaseFromtDetails(CartModel cartModel);
    }
}

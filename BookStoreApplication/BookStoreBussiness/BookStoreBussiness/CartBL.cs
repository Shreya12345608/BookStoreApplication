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

        public object AddCartDetails(CartModel cart)
        {
            return this.cartRL.AddCartDetails(cart);
        }

        public bool DeleteCartDetailsByCartId(int cartId)
        {
            return this.cartRL.DeleteCartByCartId(cartId);
        }

        public List<CartModel> GetAllBooksFromCart(string userEmail)
        {
            return this.cartRL.GetAllBooksFromCart(userEmail);
        }
    }
}


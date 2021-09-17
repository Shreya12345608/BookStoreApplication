using BookStoreModel.CartModel;
using BookStoreModel.OrderModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepository.IBookStoreRepository
{
    public interface IOrderRL
    {
        /// <summary>
        ///This method  is created for place the order.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool PlaceOrder(int userId);
    }
}

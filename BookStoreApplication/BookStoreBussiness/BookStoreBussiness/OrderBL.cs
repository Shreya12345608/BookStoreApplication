using BookStoreBussiness.IBookStoreBussiness;
using BookStoreModel.CartModel;
using BookStoreModel.OrderModel;
using BookStoreRepository.IBookStoreRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBussiness.BookStoreBussiness
{
    public class OrderBL : IOrderBL
    {
        //instance variable
        private IOrderRL orderRL;

        //constructor 
        public OrderBL(IOrderRL orderRL)
        {

            this.orderRL = orderRL;
        }
        /// <summary>
        ///This method  is created for place the order.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool PlaceOrder(int userId)
        {
            return this.orderRL.PlaceOrder(userId);
        }

    }
}

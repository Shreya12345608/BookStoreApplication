using BookStoreModel.CartModel;
using BookStoreModel.OrderModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBussiness.IBookStoreBussiness
{
  public  interface IOrderBL
    {
        /// <summary>
        ///This method  is created for place the order.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool PlaceOrder(int userId);
    }

}

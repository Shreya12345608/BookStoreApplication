﻿using BookStoreModel.OrderModel;
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
        /// <param name="UserId"></param>
        /// <param name="CartId"></param>
        /// <returns></returns>
        OrderModel PlaceOrder(int BookId, int CartId, int UserId);

        /// <summary>
        /// This method is created for placed the order from diffrents addresss
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="CartId"></param>
        /// <param name="Address"></param>
        /// <param name="City"></param>
        /// <param name="PinCode"></param>
        /// <returns></returns>
        OrderModel PlaceOrderDiffrentAddress(int UserId, int BookId, int CartId, string Address, string City, int PinCode);

        /// <summary>
        /// This method is created for veiwing the order.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        List<OrderModel> ViewOrderPlaced(int UserId);

        /// <summary>
        /// This method is created for cancel the order
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        bool CancelOrder(int UserId, int OrderId);
    }
}
using BookStoreModel.OrderModel;
using BookStoreRepository.IBookStoreRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepository.BookStoreRepository
{
   public class OrderRL : IOrderRL
    {
        string connectionString;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="configuration"></param>
        public OrderRL(IConfiguration configuration)
        {
            ///connection string
            connectionString = configuration.GetSection("ConnectionStrings").GetSection("bookStoreDB").Value;
        }

        public bool CancelOrder(int UserId, int OrderId)
        {
            throw new NotImplementedException();
        }

        public OrderModel PlaceOrder(int BookId, int CartId, int UserId)
        {
            throw new NotImplementedException();
        }

        public OrderModel PlaceOrderDiffrentAddress(int UserId, int BookId, int CartId, string Address, string City, int PinCode)
        {
            throw new NotImplementedException();
        }

        public List<OrderModel> ViewOrderPlaced(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}

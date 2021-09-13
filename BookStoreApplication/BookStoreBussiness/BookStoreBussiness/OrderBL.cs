using BookStoreBussiness.IBookStoreBussiness;
using BookStoreModel.OrderModel;
using BookStoreRepository.IBookStoreRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBussiness.BookStoreBussiness
{
    public class OrderBL :IOrderBL
    {
        //instance variable
        private IOrderRL orderRL;

        //constructor 
        public OrderBL(IOrderRL orderRL)
        {

            this.orderRL = orderRL;
        }

        public bool CancelOrder(int UserId, int OrderId)
        {
            return this.orderRL.CancelOrder(UserId, OrderId);
        }

        public OrderModel PlaceOrder(int BookId, int CartId, int UserId)
        {
            return this.PlaceOrder(BookId, CartId, UserId);
        }

        public OrderModel PlaceOrderDiffrentAddress(int UserId, int BookId, int CartId, string Address, string City, int PinCode)
        {
            return this.PlaceOrderDiffrentAddress(UserId, BookId, CartId, Address, City, PinCode);
        }

        public List<OrderModel> ViewOrderPlaced(int UserId)
        {
            return this.ViewOrderPlaced(UserId);
        }
    }
}

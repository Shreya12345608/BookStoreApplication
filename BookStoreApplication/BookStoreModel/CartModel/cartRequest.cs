using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreModel.CartModel
{
    public class cartRequest
    {
        public int CartID { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string BookImage { get; set; }
        public double TotalPrice { get; set; }
    }
}

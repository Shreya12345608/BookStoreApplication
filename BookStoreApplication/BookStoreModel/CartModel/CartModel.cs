using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStoreModel.CartModel
{
   public class CartModel
    {

        public int userId { get; set; }
        /// <summary>
        /// book id
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// cartID
        /// </summary>
        public int CartID { get; set; }
    }
}

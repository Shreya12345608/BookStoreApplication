using BookStoreModel.CartModel;
using BookStoreRepository.IBookStoreRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BookStoreRepository.BookStoreRepository
{
   public class CartRL : ICartRL
    {
        string connectionString;
        public CartRL(IConfiguration configuration)
        {
            connectionString = configuration.GetSection("ConnectionStrings").GetSection("bookStoreDB").Value;
        }

        public object AddCartDetails(CartModel cartModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spAddToCart", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    // cmd.Parameters.AddWithValue("@BookId", booksDetail.BookId);
                    command.Parameters.AddWithValue("@userId", cartModel.userId);
                    command.Parameters.AddWithValue("@bookId", cartModel.BookId);

                    connection.Open();
                    int i = command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
            }
            catch
            {
                throw;
            }
        }

    }
}

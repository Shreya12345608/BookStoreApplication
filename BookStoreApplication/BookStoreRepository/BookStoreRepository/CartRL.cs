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

      

        public List<CartModel> GetAllBooksFromCart(int userId)
        {
            try
            {
                List<CartModel> cartlist = new List<CartModel>();
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spGetallCart", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userId", userId);
                    connection.Open();
                    SqlDataReader sqlreader = command.ExecuteReader();
                    while (sqlreader.Read())
                    {
                        var cart = new CartModel();
                        cart.BookId = Convert.ToInt32(sqlreader["BookId"]);
                        cart.CartID = Convert.ToInt32(sqlreader["CartID"]);
                        cart.Quantity = Convert.ToInt32(sqlreader["Quantity"]);
                        cart.userEmail = sqlreader["userEmail"].ToString();
                        cart.BookName = sqlreader["BookName"].ToString();
                        cart.AuthorName = sqlreader["AuthorName"].ToString();
                        cart.Price = Convert.ToDouble(sqlreader["Price"]);
                        cart.Description = sqlreader["Description"].ToString();
                        cart.BookImage = sqlreader["BookImage"].ToString();
                        cart.Rating = Convert.ToDouble(sqlreader["Rating"]);
                        cart.TotalPrice = Convert.ToInt32(sqlreader["Price"]) * Convert.ToInt32(sqlreader["Count"]);
                        cartlist.Add(cart);
                    }
                    connection.Close();
                }
                return cartlist;
            }
            catch
            {
                throw;
            }
        }
    }
}



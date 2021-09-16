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

        public object AddCartDetails(CartModel cartModel, int userId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spAddToCart", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userId", userId);
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

        public object decreaseFromtDetails(CartModel cartModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// delete cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public bool DeleteCart(cartRequest cart)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    // Implementing the stored procedure
                    SqlCommand command = new SqlCommand("spDeleteFromCart", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CartId", cart.CartID);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    //Return the result of the transaction 

                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<cartRequest> GetAllBooksFromCart(int userId)
        {
            try
            {
                List<cartRequest> cartlist = new List<cartRequest>();
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
                        var cart = new cartRequest();
                        cart.BookId = Convert.ToInt32(sqlreader["BookId"]);
                        cart.CartID = Convert.ToInt32(sqlreader["CartID"]);
                        cart.BookName = sqlreader["BookName"].ToString();
                        cart.AuthorName =sqlreader["AuthorName"].ToString();
                        cart.Description = sqlreader["Description"].ToString();
                        cart.Quantity = Convert.ToInt32(sqlreader["Quantity"]);
                        cart.Price = Convert.ToInt32(sqlreader["Price"]);
                        cart.BookImage = sqlreader["BookImage"].ToString();
                       // cart.TotalPrice = Convert.ToInt32(sqlreader["Price"]) * Convert.ToInt32(sqlreader["Count"]);
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



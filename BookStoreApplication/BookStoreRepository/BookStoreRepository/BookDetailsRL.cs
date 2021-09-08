using BookStoreModel.BooksModel;
using BookStoreRepository.IBookStoreRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BookStoreRepository.BookStoreRepository
{
    public class BookDetailsRL : IBookDetailsRL
    {
        string connectionString;
        ///connection string
        public BookDetailsRL(IConfiguration configuration)
        {
            ///connection string
            connectionString = configuration.GetSection("ConnectionStrings").GetSection("bookStoreDB").Value;
        }


        /// <summary>
        /// add Book 
        /// </summary>
        /// <param name="booksDetail"></param>
        /// <returns></returns>
        public object AddBookDetails(BooksModel booksDetail)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("spAddBooks", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    // cmd.Parameters.AddWithValue("@BookId", booksDetail.BookId);
                    cmd.Parameters.AddWithValue("@BookName", booksDetail.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", booksDetail.AuthorName);
                    cmd.Parameters.AddWithValue("@Price", booksDetail.Price);
                    cmd.Parameters.AddWithValue("@Quantity", booksDetail.Quantity);
                    cmd.Parameters.AddWithValue("@Description", booksDetail.Description);
                    cmd.Parameters.AddWithValue("@BookImage", booksDetail.BookImage);
                    cmd.Parameters.AddWithValue("@Rating", booksDetail.Rating);

                    connection.Open();
                    int i = cmd.ExecuteNonQuery();
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


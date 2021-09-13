using BookStoreRepository.IBookStoreRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BookStoreRepository.BookStoreRepository
{
    public class AddressRL : IAddressRL
    {
        string connectionString;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="configuration"></param>
        public AddressRL(IConfiguration configuration)
        {
            ///connection string
            connectionString = configuration.GetSection("ConnectionStrings").GetSection("bookStoreDB").Value;
        }

        public bool AddNewAddress(int userId, string address)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    // Implementing the stored procedure
                    SqlCommand command = new SqlCommand("spAddNewAddress", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@address",address);
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

        public List<IEnumerable<string>> GetAllAddress(int userId)
        {
            throw new NotImplementedException();
        }
    }
}

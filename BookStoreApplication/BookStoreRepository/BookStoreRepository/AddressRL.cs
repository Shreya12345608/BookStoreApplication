using BookStoreModel.AddressModel;
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

        public bool AddNewAddress(int userId, AddressModel address)
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
                    command.Parameters.AddWithValue("@address", address.address);
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


        public List<AddressModel> GetAllAddress(int userId)
        {
            try
            {
                List<AddressModel> addressList = new List<AddressModel>();
                SqlConnection connection = new SqlConnection(connectionString);
                {
                    SqlCommand command = new SqlCommand("spGetAllAddress", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userId", userId);
                    connection.Open();
                    SqlDataReader sqlreader = command.ExecuteReader();
                    while (sqlreader.Read())
                    {
                        AddressModel address = new AddressModel();
                        address.address = sqlreader["address"].ToString();

                        addressList.Add(address);
                    }
                    connection.Close();
                }
                return addressList;
            }

            catch
            {
                throw;
            }
        }
    }
}

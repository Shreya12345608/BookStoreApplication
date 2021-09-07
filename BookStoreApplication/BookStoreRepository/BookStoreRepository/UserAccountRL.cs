using BookStoreModel.AccountModel;
using BookStoreRepository.IBookStoreRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BookStoreRepository.BookStoreRepository
{
    public class UserAccountRL : IUserAccountRL
    {
        string connectionString;
        public UserAccountRL(IConfiguration configuration)
        {
            connectionString = configuration.GetSection("ConnectionStrings").GetSection("bookStoreDB").Value;
        }


        public bool AddUserDetails(Registration user)
        {
            //    Registration registration = new Registration()
            //    {
            //        fullName = connectionString
            //};
            //return registration;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    // Implementing the stored procedure
                    SqlCommand command = new SqlCommand("spuserRegistration", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fullName", user.fullName);
                    command.Parameters.AddWithValue("@userEmail", user.userEmail);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    connection.Open();
                    var result = command.ExecuteNonQuery();

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
    }
}


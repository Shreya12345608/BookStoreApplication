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
        
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="configuration"></param>
        public UserAccountRL(IConfiguration configuration)
        {
            ///connection string
            connectionString = configuration.GetSection("ConnectionStrings").GetSection("bookStoreDB").Value;
        }

        /// <summary>
        /// Add User 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUserDetails(Registration user)
        {
      
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


        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>

        public UserLogin Login(UserLogin login)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    // Implementing the stored procedure
                    SqlCommand command = new SqlCommand("spLogin", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userEmail", login.userEmail);
                    command.Parameters.AddWithValue("@Password", login.Password);
                    connection.Open();
                    var result = command.ExecuteNonQuery();

                    //Return the result of the transaction 
                    if (result != 0)
                    {
                        connection.Close();
                        return login;
                    }
                    connection.Close();
                    return null;
                }
            }
            catch
            {

                throw;
            }
        }

    }
}


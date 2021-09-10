using BookStoreModel.AccountModel;
using BookStoreModel.AdminModel;
using BookStoreRepository.IBookStoreRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BookStoreRepository.BookStoreRepository
{
    public class AdminRL : IAdminRL
    {
        string connectionString;
        string Secret;
        public AdminRL(IConfiguration configuration)
        {
            Secret = configuration.GetSection("AppSettings").GetSection("Secret").Value;
            ///connection string
            connectionString = configuration.GetSection("ConnectionStrings").GetSection("bookStoreDB").Value;
        }
        public userResponse LoginAdmin(Registration user)
        {
            throw new NotImplementedException();
        }

        public bool RegisterAdmin(Admin userData)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    // Implementing the stored procedure
                    SqlCommand command = new SqlCommand("spuserRegistration", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fullName", userData.fullName);
                    command.Parameters.AddWithValue("@userEmail", userData.userEmail);
                    command.Parameters.AddWithValue("@Password", userData.Password);
                    command.Parameters.AddWithValue("@PhoneNumber", userData.PhoneNumber);
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
    }
}

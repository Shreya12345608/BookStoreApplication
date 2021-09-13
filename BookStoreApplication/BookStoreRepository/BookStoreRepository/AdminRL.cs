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

        public bool RegisterAdmin(Admin adminData)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    // Implementing the stored procedure
                    SqlCommand command = new SqlCommand("spadminRegistration", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fullName", adminData.fullName);
                    command.Parameters.AddWithValue("@userEmail", adminData.userEmail);
                    command.Parameters.AddWithValue("@Password", adminData.Password);
                    command.Parameters.AddWithValue("@roleName", adminData.roleName);
                    command.Parameters.AddWithValue("@PhoneNumber", adminData.PhoneNumber);
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
        public Registration LoginAdmin(string userEmail)
        {
            Registration reges = new Registration();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    // Implementing the stored procedure
                    SqlCommand command = new SqlCommand("spadminLogin", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userEmail",userEmail);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        reges.Userid = Convert.ToInt32(reader["userId"]);
                        reges.fullName = reader["fullName"].ToString();
                        reges.userEmail = reader["userEmail"].ToString();
                        reges.Password = reader["Password"].ToString();
                        reges.PhoneNumber = reader["PhoneNumber"].ToString(); 
                    }
                    if (reges != null)
                    {
                        return reges;
                    }
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

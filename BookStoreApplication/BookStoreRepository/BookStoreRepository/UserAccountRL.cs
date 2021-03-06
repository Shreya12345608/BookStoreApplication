using BookStoreBussiness.MSMQUtility;
using BookStoreModel.AccountModel;
using BookStoreRepository.IBookStoreRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStoreRepository.BookStoreRepository
{
    public class UserAccountRL : IUserAccountRL
    {
        string connectionString;
        string Secret;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="configuration"></param>
        public UserAccountRL(IConfiguration configuration)
        {
            Secret = configuration.GetSection("AppSettings").GetSection("Secret").Value;
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
                    command.Parameters.AddWithValue("@roleName", "User");
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
        /// forget Password
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public bool ForgotPassword(string userEmail)
        {
            Registration reges = new Registration();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    // implementing the stored procedure
                    SqlCommand command = new SqlCommand("spforgetPassword", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@userEmail", userEmail);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        reges.Userid = Convert.ToInt32(reader["userId"]);
                        reges.fullName = reader["fullName"].ToString();
                        reges.userEmail = reader["userEmail"].ToString();
                        reges.Password = reader["Password"].ToString();
                        reges.PhoneNumber = reader["PhoneNumber"].ToString(); ;
                    }
                    bool result;
                    if (reges != null)
                    {
                        string token = CreateToken(reges.userEmail, reges.Userid,reges.roleName);
                        msmqUtility msmq = new msmqUtility(Secret);
                        msmq.SendMessage(userEmail, token);

                        result = true;
                        return result;
                    }
                    result = false;
                    return result;


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

        public Registration Login(UserLogin login)
        {
            Registration reges = new Registration();
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
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        reges.Userid = Convert.ToInt32(reader["userId"]);
                        reges.fullName = reader["fullName"].ToString();
                        reges.userEmail = reader["userEmail"].ToString();
                        reges.Password = reader["Password"].ToString();
                        reges.PhoneNumber = reader["PhoneNumber"].ToString();
                        reges.roleName = reader["roleName"].ToString(); 

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
        //-----------------------------------CREATE TOKEN-----------------------------------------------//
        /// <summary>
        /// Token Crreated
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string CreateToken(string userEmail, int userId, string roleName)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            var tokenDescpritor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Email, userEmail),
                        new Claim("userId", userId.ToString(), ClaimValueTypes.Integer),
                        new Claim(ClaimTypes.Role , roleName),
                    }),
                Expires = DateTime.UtcNow.AddMinutes(360),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescpritor);
            string jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;

        }




        /// <summary>
        /// This method is created for reset pasword of users.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        
        public bool ResetPassword(ResetPassword reset, int userId)

        {
          
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("spResetPassword", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@Password", reset.NewPassword);
                    connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    connection.Close();
                    //return the result of the transaction 
                    if (result != -1)
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


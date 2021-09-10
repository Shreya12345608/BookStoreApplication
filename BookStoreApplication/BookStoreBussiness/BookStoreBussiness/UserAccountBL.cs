using BookStoreBussiness.IBookStoreBussiness;
using BookStoreBussiness.MSMQUtility;
using BookStoreModel.AccountModel;
using BookStoreRepository.IBookStoreRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStoreBussiness.BookStoreBussiness
{
    public class UserAccountBL : IUserAccountBL
    {
        //instance variable
        private IUserAccountRL BookStoreUser;
        string Secret;
        //constructor 
        public UserAccountBL(IUserAccountRL BookStoreUser, IConfiguration configuration)
        {

            this.BookStoreUser = BookStoreUser;
        }

        /// <summary>
        /// Add user in Book Store
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUserDetails(Registration user)
        {
            try
            {
                return this.BookStoreUser.AddUserDetails(user);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// login  Book Store
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public Registration Login(UserLogin login)
        {
            return this.BookStoreUser.Login(login);
        }

        /// <summary>
        ///  Method for  Forget password.
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public bool ForgotPassword(string userEmail)
        {
            try
            {
                return BookStoreUser.ForgotPassword(userEmail);
            }
            catch
            {
                throw;
            }

        }


        /// <summary>
        /// Method for reset password
        /// </summary>
        /// <param name="reset"></param>
        /// <returns></returns>
       
        

        /// <summary>
        /// token
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string CreateToken(string userEmail, int userId)
        {
            try
            {
                return BookStoreUser.CreateToken(userEmail, userId);

            }
            catch
            {

                throw;
            }
        }

        public Registration ResetPassword(string email, ResetPassword resetPassword)
        {
            throw new NotImplementedException();
        }
    }
}

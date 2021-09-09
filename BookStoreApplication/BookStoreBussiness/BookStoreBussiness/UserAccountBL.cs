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
        public int Login(UserLogin login)
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



        public bool ResetPassword(ResetPassword reset, int userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method for reset password
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        //public bool ResetPassword(ResetPassword reset, int userId)
        //{
        //    try
        //    {
        //        return BookStoreUser.ResetPassword(reset, newPassword);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }
}

using BookStoreBussiness.IBookStoreBussiness;
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
            Secret = configuration.GetSection("AppSettings").GetSection("Secret").Value;
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
        public UserLogin Login(UserLogin login)
        {
            return this.BookStoreUser.Login(login);
        }





    }
}
   
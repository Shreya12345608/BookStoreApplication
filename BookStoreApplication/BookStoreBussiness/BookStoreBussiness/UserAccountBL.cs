using BookStoreBussiness.IBookStoreBussiness;
using BookStoreModel.AccountModel;
using BookStoreRepository.IBookStoreRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBussiness.BookStoreBussiness
{
    public class UserAccountBL : IUserAccountBL
    {
        //instance variable
        private IUserAccountRL BookStoreUser;

        //constructor 
        public UserAccountBL(IUserAccountRL BookStoreUser)
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
            return this.BookStoreUser.AddUserDetails(user);
        }
    }
}
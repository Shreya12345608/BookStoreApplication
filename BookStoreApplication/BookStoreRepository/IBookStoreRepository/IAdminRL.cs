using BookStoreModel.AccountModel;
using BookStoreModel.AdminModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepository.IBookStoreRepository
{
   public interface IAdminRL
    {
        /// <summary>
        /// admin register
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        public bool RegisterAdmin(Admin userData);

        /// <summary>
        /// Login for User
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        Admin Login(UserLogin login);
    }
}

using BookStoreModel.AccountModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepository.IBookStoreRepository
{
   public interface IUserAccountRL
    {
        /// <summary>
        /// Registration for new User
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        public bool AddUserDetails(Registration user);
    }
}

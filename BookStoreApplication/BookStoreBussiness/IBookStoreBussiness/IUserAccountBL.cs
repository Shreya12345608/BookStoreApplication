using BookStoreModel.AccountModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBussiness.IBookStoreBussiness
{
    public interface IUserAccountBL
    {
        /// <summary>
        /// Registration for new User
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
       public bool AddUserDetails(Registration user);
    }
}

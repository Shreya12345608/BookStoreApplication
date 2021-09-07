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
      
        /// <summary>
        /// Login for User
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        UserLogin Login(UserLogin login);

        /// <summary>
        /// Forger password
        /// </summary>
        /// <param name="UserEmail"></param>
        /// <returns></returns>
        public bool ForgotPassword(string UserEmail);

        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="reset"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool ResetPassword(ResetPassword reset, int userId)
    }

   
}

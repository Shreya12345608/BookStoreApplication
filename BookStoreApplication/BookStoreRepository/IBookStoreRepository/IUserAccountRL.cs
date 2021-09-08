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
        /// Resetpassword for User
        /// </summary>
        /// <param name="userReset"></param>
        /// <returns></returns>
        object ResetPassword(string email, string password);
    }

  
}

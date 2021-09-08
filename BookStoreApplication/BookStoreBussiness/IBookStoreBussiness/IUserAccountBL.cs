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
        /// Create token
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string CreateToken(string userEmail, int userId);

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

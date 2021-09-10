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
        Registration Login(UserLogin login);

        

        /// <summary>
        /// Forger password
        /// </summary>
        /// <param name="UserEmail"></param>
        /// <returns></returns>
        public bool ForgotPassword(string userEmail);


        public string CreateToken(string userEmail, int userId);
        /// <summary>
        /// Reset Password Method
        /// </summary>
        /// <param name="resetPassword">Reset Password</param>
        /// <returns>boolean result</returns>
        public Registration ResetPassword(string email, ResetPassword resetPassword);
    }
    
   
}

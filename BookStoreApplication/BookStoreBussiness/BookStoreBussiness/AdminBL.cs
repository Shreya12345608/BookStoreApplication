using BookStoreBussiness.IBookStoreBussiness;
using BookStoreModel.AccountModel;
using BookStoreModel.AdminModel;
using BookStoreRepository.IBookStoreRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBussiness.BookStoreBussiness
{
    public class AdminBL : IAdminBL
    {
        //instance variable
        private IAdminRL adminRL;
     
        //constructor 
        public AdminBL(IAdminRL adminRL)
        {

            this.adminRL = adminRL;
        }

        /// <summary>
        /// login  Book Store
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public Admin Login(UserLogin login)
        {
            return this.adminRL.Login(login);
        }
     

         public bool RegisterAdmin(Admin adminData)
        {
            return this.adminRL.RegisterAdmin(adminData);
        }
    }
}

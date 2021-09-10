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
        string Secret;
        //constructor 
        public AdminBL(IAdminRL adminRL)
        {

            this.adminRL = adminRL;
        }

        public userResponse LoginAdmin(Registration user)
        {
            return this.adminRL.LoginAdmin(user);
        }

         public bool RegisterAdmin(Admin userData)
        {
            return this.adminRL.RegisterAdmin(userData);
        }
    }
}

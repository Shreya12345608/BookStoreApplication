using BookStoreBussiness.IBookStoreBussiness;
using BookStoreModel.AddressModel;
using BookStoreRepository.IBookStoreRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBussiness.BookStoreBussiness
{
    public class AddressBL :IAddressBL
    {
        public IAddressRL addressRL;
        public AddressBL(IAddressRL addressRL)
        {
            this.addressRL = addressRL;
        }

        public bool AddNewAddress(int userId, AddressModel address)
        {
            return this.addressRL.AddNewAddress(userId, address);
        }

        public List<AddressModel> GetAllAddress(int userId)
        {
            return this.addressRL.GetAllAddress(userId);
        }
    }
}

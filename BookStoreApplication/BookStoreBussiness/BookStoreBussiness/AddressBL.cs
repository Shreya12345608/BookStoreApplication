using BookStoreBussiness.IBookStoreBussiness;
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

        public bool AddNewAddress(int userId, string address)
        {
            return this.addressRL.AddNewAddress(userId, address);
        }

        public List<IEnumerable<string>> GetAllAddress(int userId)
        {
            throw new NotImplementedException();
        }
    }
}

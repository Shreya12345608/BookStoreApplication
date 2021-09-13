using BookStoreModel.AddressModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepository.IBookStoreRepository
{
  public  interface IAddressRL
    {
        /// <summary>
        /// Add Address Details
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool AddNewAddress(int userId, AddressModel address);
        /// <summary>
        /// Get all Address Details
        /// </summary>
        /// <returns></returns>
        public List<AddressModel> GetAllAddress(int userId);
    }
}

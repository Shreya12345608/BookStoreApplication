using BookStoreModel.AddressModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBussiness.IBookStoreBussiness
{
    public interface IAddressBL
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

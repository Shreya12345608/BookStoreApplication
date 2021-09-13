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
        public bool AddNewAddress(int userId, string address);
        /// <summary>
        /// Get all Address Details
        /// </summary>
        /// <returns></returns>
        List<IEnumerable<string>> GetAllAddress(int userId);
    }
}

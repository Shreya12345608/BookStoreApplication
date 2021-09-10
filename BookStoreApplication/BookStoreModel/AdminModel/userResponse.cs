using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreModel.AdminModel
{
    public class userResponse
    {
      
        /// <summary>
        /// userid
        /// </summary>
        public int Userid { get; set; }
     
        /// <summary>
        /// full name
        /// </summary>
        public string fullName { get; set; }
        
        /// <summary>
        /// userEmail
        /// </summary>
        public string userEmail { get; set; }
       
        /// <summary>
        /// role
        /// </summary>
        public string Role { get; set; }
    }
}

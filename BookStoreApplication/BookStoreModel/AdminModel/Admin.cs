using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStoreModel.AdminModel
{
   public class Admin
    {
        public int Adminid { get; set; }
        // For First Name
        [Required(ErrorMessage = "Full Name is required")]
        [RegularExpression(@"^[a-zA-Z]+([\s][a-zA-Z]+)*", ErrorMessage = "Please enter a valid Full Name ")]
        public string fullName { get; set; }

        //For Email
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9]+[._+-]{0,1}[0-9a-zA-Z]+[@][a-zA-Z]+[.][a-zA-Z]{2,3}([.][a-zA-Z]{2,3}){0,1}$", ErrorMessage = "Please enter a valid email address")]
        public string userEmail { get; set; }
        //For Email
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[0-9])(?=.*[&%$#@^*!~]).{8,}$", ErrorMessage = "Please enter a valid Password")]
        //For PAssword
        public string Password { get; set; }

        /// This is  phone number of users.
        [Required(ErrorMessage = "Phone No is required")]
        [RegularExpression(@"^[0-9]{10}", ErrorMessage = "Please enter a valid Phone No")]
        public string PhoneNumber { get; set; }
       public string roleName { get; set; }
    }
}


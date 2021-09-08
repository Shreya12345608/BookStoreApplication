using BookStoreBussiness.IBookStoreBussiness;
using BookStoreBussiness.MSMQUtility;
using BookStoreModel.AccountModel;
using BookStoreRepository.IBookStoreRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStoreBussiness.BookStoreBussiness
{
    public class UserAccountBL : IUserAccountBL
    {
        //instance variable
        private IUserAccountRL BookStoreUser;
        string Secret;
        //constructor 
        public UserAccountBL(IUserAccountRL BookStoreUser, IConfiguration configuration)
        {
            Secret = configuration.GetSection("AppSettings").GetSection("Secret").Value;
            this.BookStoreUser = BookStoreUser;
        }

        /// <summary>
        /// Add user in Book Store
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUserDetails(Registration user)
        {
            try
            {
                return this.BookStoreUser.AddUserDetails(user);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// login  Book Store
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public UserLogin Login(UserLogin login)
        {
            return this.BookStoreUser.Login(login);
        }

        /// <summary>
        ///  Method for  Forget password.
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public bool ForgotPassword(string UserEmail)
        {
            try
            {
                bool result;
                // string mailSubject = "Link to reset your FundooNotes App Credentials";
                //var userCheck = this.fundooContext.FondooNotes.SingleOrDefault(x => x.UserEmail == UserEmail);
                var existingUser =BookStoreUser.ForgotPassword(UserEmail);
                if (existingUser != null)
                {
                   // string token = CreateToken(existingUser.UserEmail, existingUser.Userid);
                    msmqUtility msmq = new msmqUtility(Secret);
                  //  msmq.SendMessage(UserEmail, token);
                    result = true;
                    return result;
                }
                result = false;
                return result;
            }
            catch
            {
                throw;
            }
           
        }

        //-----------------------------------CREATE TOKEN-----------------------------------------------//
        /// <summary>
        /// Token Crreated
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string CreateToken(string userEmail, int userId)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            var tokenDescpritor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Email, userEmail),
                        new Claim("userId", userId.ToString(), ClaimValueTypes.Integer),
                    }),
                Expires = DateTime.UtcNow.AddMinutes(120),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescpritor);
            string jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;

        }

        /// <summary>
        /// reset password
        /// </summary>
        /// <param name="reset"></param>
        /// <param name="userId"></param>
        /// <returns></returns>

        public object ResetPassword(string email, string password)
        {
            return this.BookStoreUser.ResetPassword(email, password);
        }
    }
}
   
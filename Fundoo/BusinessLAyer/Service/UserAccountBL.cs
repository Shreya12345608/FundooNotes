﻿using BusinessLAyer.Interface;
using CommanLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLAyer.Service
{
    public class UserAccountBL : IUserAccountBL
    {
        //instance variable
        private IUserAccountRL fundoo;
        private string Secret;
        //constructor for class FundooBL 
        public UserAccountBL(IUserAccountRL fundoo, IConfiguration configuration)
        {
            Secret = configuration.GetSection("AppSettings").GetSection("Secret").Value;
            this.fundoo = fundoo;
        }
        //-------------------------ADD USER------------------------------------------//
        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="adduser"></param>
        /// <returns></returns>
        public UserAccountDetails AddUser(UserAccountDetails adduser)
        {
            try
            {
                fundoo.AddUser(adduser);
                return adduser;
            }
            catch
            {
                throw;
            }
        }
        //---------------------------------GET DETAILS-------------------------------------------------//

        /// <summary>
        /// Method for   Get USer
        /// </summary>
        /// <returns></returns>
        public List<UserAccountDetails> GetFundoo()
        {
            try
            {
                return this.fundoo.GetFundoo();
            }
            catch
            {
                throw;
            }
        }
        //----------------------------LOGIN ACCOUNT---------------------------------------------//
        /// <summary>
        ///  Method for  Login Account 
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserAccountDetails LoginAccount(string userEmail, string password)
        {
            try
            {

                return this.fundoo.UserLogin(userEmail, password);

            }
            catch
            {
                throw;
            }
        }
        //---------------------------------FORGET PASSWORD-------------------------------------------------//
        /// <summary>
        ///  Method for  Forget password.
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public bool ForgotPassword(string UserEmail)
        {
            try
            {

                return this.fundoo.ForgotPassword(UserEmail);
            }
            catch
            {
                throw;
            }
        }
        //---------------------------------RESET PASSWORD-------------------------------------------------//
        /// <summary>
        /// Method for reset password
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        public bool ResetPassword(ResetPassword resetPassword)
        {
            try
            {
                return this.fundoo.ResetPassword(resetPassword);
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
        public string CreateToken(string userEmail, int userid)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            var tokenDescpritor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Email, userEmail),
                        new Claim("userid", userid.ToString(), ClaimValueTypes.Integer),
                    }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescpritor);
            string jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;
        }



        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public Fundoos GetFundooUser(int id)
        //{
        //    return fundoo.GetFundooUser(id);
        //}

    }
}
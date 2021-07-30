using BusinessLAyer.Interface;
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
        private IUserAccountRL fundoo;
        private string Secret;
        //constructor for class FundooBL
        public UserAccountBL(IUserAccountRL fundoo, IConfiguration configuration)
        {
            Secret = configuration.GetSection("AppSettings").GetSection("Secret").Value;
            this.fundoo = fundoo;
        }
        //----------------------------------------//
        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="adduser"></param>
        /// <returns></returns>
        public UserAccountDetails AddUser(UserAccountDetails adduser)
        {
            fundoo.AddUser(adduser);
            return adduser;
        }

        public string ForgetPasswordModel(ForgetPasswordModel forgetPassword)
        {
            throw new NotImplementedException();
        }

        //----------------------------------------//

        /// <summary>
        /// Get USer
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
        /// <summary>
        /// Login Account 
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserAccountDetails LoginAccount(string userEmail, string password)
        {
            try
            {
                
                return this.fundoo.UserLogin(userEmail,password);
                
            }
           catch
            {
                throw;
            } 
        }
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
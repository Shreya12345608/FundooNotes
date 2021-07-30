using CommanLayer;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RepositoryLayer.Service
{
    public class FunfooDbRL : IUserAccountRL
    {
        private FundooContext fundooContext;
        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="fundooContext"></param>
        public FunfooDbRL(FundooContext fundooContext)
        {

            this.fundooContext = fundooContext;

        }



        /// <summary>
        /// List user from database
        /// </summary>
        /// <returns></returns>
        public List<UserAccountDetails> GetFundoo()
        {
            try
            {
                return fundooContext.FondooNotes.ToList();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Add user in db
        /// </summary>
        /// <param name="addUser"></param>
        /// <returns></returns>
        public UserAccountDetails AddUser(UserAccountDetails addUser)
        {
            try
            {

                addUser.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                addUser.ModifiedDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                fundooContext.FondooNotes.Add(addUser);
                fundooContext.SaveChanges();
                return addUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// User login 
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserAccountDetails UserLogin(string userEmail, string password)
        {
            try
            {
                string pass = EncryptPassword(password);
                UserAccountDetails userValidation = fundooContext.FondooNotes.FirstOrDefault(user => user.UserEmail == userEmail && user.Password == password);
                //UserAccountDetails userAccountDetails = new UserAccountDetails();
                //userAccountDetails.Password = pass;
                return userValidation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// ability to retrieve password from the database 
        /// after validating email.
        /// </summary>
        /// <param name="forgetPassword"></param>
        /// <returns></returns>
        public string ForgetPasswordModel(ForgetPasswordModel forgetPassword)
        {
            throw new NotImplementedException();
        }

        private static string EncryptPassword(string Password)
        {
            //SHA1 hash value for the input data using the
            //implementation provided by the cryptographic service provider (CSP)
            var provider = new SHA1CryptoServiceProvider();
            //Represents a UTF-16 encoding of Unicode characters.
            var encoding = new UnicodeEncoding();
            byte[] encrypt = provider.ComputeHash(encoding.GetBytes(Password));
            String encrypted = Convert.ToBase64String(encrypt);
            return encrypted;
        }
       
    }
}
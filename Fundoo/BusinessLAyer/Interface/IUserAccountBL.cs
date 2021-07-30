using CommanLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLAyer.Interface
{
    public interface IUserAccountBL
    {
       /// <summary>
       /// list all the user
       /// </summary>
       /// <returns></returns>
        List<UserAccountDetails> GetFundoo();
        /// <summary>
        ///add new user
        /// </summary>
        /// <param name="adduser"></param>
        /// <returns></returns>
        UserAccountDetails AddUser(UserAccountDetails adduser);
        /// <summary>
        /// login user
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserAccountDetails LoginAccount(string userEmail , string password);
        /// <summary>
        /// Create token
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        string CreateToken(string userEmail, int userid);
        /// <summary>
        /// Forger password
        /// </summary>
        /// <param name="UserEmail"></param>
        /// <returns></returns>
        bool ForgotPassword(string UserEmail);

        /// <summary>
        /// Reset Password Method
        /// </summary>
        /// <param name="resetPassword">Reset Password</param>
        /// <returns>boolean result</returns>
        public bool ResetPassword(ResetPassword resetPassword);
    }

}

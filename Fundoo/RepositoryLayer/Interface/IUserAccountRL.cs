using CommanLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserAccountRL
    {
        /// <summary>
        /// list of model class
        /// </summary>
        /// <returns></returns>
        List<UserAccountDetails> GetFundoo();
        /// <summary>
        /// Add New User
        /// </summary>
        /// <param name="adduser"></param>
        ///<returns></returns>
        UserAccountDetails AddUser(UserAccountDetails adduser);
        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        UserAccountDetails UserLogin(string userEmail, string password);
        /// <summary>
        /// Forget Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool ForgotPassword(string UserEmail);

    }
}

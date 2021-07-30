using CommanLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLAyer.Interface
{
    public interface IUserAccountBL
    {
        //list of Fundoo 
        List<UserAccountDetails> GetFundoo();
        //add new user
        UserAccountDetails AddUser(UserAccountDetails adduser);
        UserAccountDetails LoginAccount(string userEmail , string password);
        string CreateToken(string userEmail, int userid);
        string ForgetPasswordModel(ForgetPasswordModel forgetPassword);
    }

}

using CommanLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Service
{
    public class FundooRL : IUserAccountRL
    {
        List<UserAccountDetails> fundoo = new List<UserAccountDetails>()
        {
            new UserAccountDetails(){ Userid = 1, FirstName = "Shreya", LastName = "M",UserEmail ="malviyashreya26@gmail.com",Password = "Shreya@987",CreatedDate ="1/1/2021",ModifiedDate="5/1/2021"},
            new UserAccountDetails(){ Userid = 2, FirstName = "Prajakta", LastName = "B",UserEmail ="prajakta123@gmail.com", Password = "Prajakta@987",CreatedDate ="4/2/2021",ModifiedDate="5/3/2021"},
            new UserAccountDetails(){ Userid = 3, FirstName = "Ekta", LastName = "S",UserEmail ="ektaSh26@gmail.com", Password = "Ekta@987",CreatedDate ="1/3/2021",ModifiedDate="5/4/2021"}
        };
        /// <summary>
        /// Add User  auto increment userid +1
        /// </summary>
        /// <param name="adduser"></param>
        /// <returns></returns>
        public UserAccountDetails AddUser(UserAccountDetails adduser)
        {
            try
            {
                adduser.Userid = fundoo.Count + 1;
                fundoo.Add(adduser);
                return adduser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ForgetPasswordModel(ForgetPasswordModel forgetPassword)
        {
            throw new NotImplementedException();
        }

        public string ForgetPasswordModel(string UserEmail)
        {
            throw new NotImplementedException();
        }

        public bool ForgotPassword(string UserEmail)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// List of hard coded value
        /// </summary>
        /// <returns></returns>
        public List<UserAccountDetails> GetFundoo()
        {
            try
            {
                return fundoo;

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UserAccountDetails UserLogin(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }

        public UserAccountDetails UserLogin(string userEmail, string password)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// get details by using id
        ///by using lambda expression
        /// </summary>
        /// <param name="Userid"></param>
        /// <returns></returns>
        //public Fundoos GetFundooUser(int Userid)
        //{
        //    return fundoo.Find(x => x.Userid == Userid);
        //}
    }
}

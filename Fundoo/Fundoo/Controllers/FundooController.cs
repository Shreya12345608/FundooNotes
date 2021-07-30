using BusinessLAyer.Interface;
using CommanLayer;
using Google.Apis.Admin.Directory.directory_v1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Fundoo.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FundooController : ControllerBase
    {
        //instance variable
        private IUserAccountBL Fundoo;
        /// <summary>
        /// constructor for FundooController
        /// </summary>
        /// <param name="fundoo"></param>
        public FundooController(IUserAccountBL fundoo)
        {
            this.Fundoo = fundoo;
        }
        /// <summary>
        /// Controller method for Adds the specified model.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetFundoo()
        {
            try
            {
                var fundoos = Fundoo.GetFundoo();
                return this.Ok(new { Success = true, Message = "Get User SuccessFull", Data = fundoos });
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { Success = false, Message = ex.Message, StackTrace = ex.StackTrace });
            }
        }

        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpGet]
        //[Route("{id}")]
        //public ActionResult GetFundooUser(int id)
        //{
        //    var fundoo = Fundoo.GetFundooUser(id);
        //    return Ok(new {Success = true , Message = "Get User By ID", Data = fundoo });
        //}
        
        
        [HttpPost]
        public ActionResult AddUser(UserAccountDetails adduser)
        {
            try
            {
                Fundoo.AddUser(adduser);
                return Created(adduser.Userid.ToString(), adduser);
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { Success = false, Message = ex.Message, StackTrace = ex.StackTrace });
            }
        }
        /// <summary>
        ///Controller method for Logins the instance.
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public ActionResult UserLogin(LoginModel loginModel)
        {
            try
            {

                var users = Fundoo.LoginAccount(loginModel.UserEmail, loginModel.Password);
                if (users != null)
                {
                    string Token = Fundoo.CreateToken(users.UserEmail, users.Userid);
                    return Ok(new { sucess = true, message = "Valid details", Data = Token });

                }
                return NotFound(new { sucess = false, message = "Invalid details" });
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { Success = false, Message = ex.Message, StackTrace = ex.StackTrace });
            }
        }
        /// <summary>
        /// Controller method for Forget Password
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("forget-Password")]
        public ActionResult ForgotPassword(ForgetPasswordModel user)
        {
            try
            {
                bool forgetpass = Fundoo.ForgotPassword(user.UserEmail);
                if (forgetpass)
                {
                    return Ok(new { Success = true, message = "Valid details", Data = forgetpass });

                }
                return NotFound(new { Sucess = false, message = "No user Exist" });
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { Success = false, Message = ex.Message, StackTrace = ex.StackTrace });
            }

        }
        /// <summary>
        /// Controller method for Reset Password
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("reset-password")]
        public ActionResult ResetPassword(ResetPassword resetPassword)
        {
            try
            {
                bool resetPaswrd = Fundoo.ResetPassword(resetPassword);
                if (resetPaswrd)
                {
                    return Ok(new { Success = true, message = "Password Reset Successfully", Data = resetPaswrd });
                }
                return NotFound(new { Sucess = false, message = "Failed to Reset Password." });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message, StackTrace = ex.StackTrace });
            }

        }
    }
}

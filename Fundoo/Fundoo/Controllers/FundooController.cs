﻿using BusinessLAyer.Interface;
using CommanLayer;
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
        private IUserAccountBL Fundoo;
        public FundooController(IUserAccountBL fundoo)
        {
            this.Fundoo = fundoo;
        }
        /// <summary>
        /// Adds the specified model.
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
        ///Logins the instance.
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
                    return NotFound(new { sucess = false, message = "Invalid details", Data = Token });

                }
                return NotFound(new { sucess = false, message = "Invalid details" });
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { Success = false, Message = ex.Message, StackTrace = ex.StackTrace});
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CommanLayer
{
    /// <summary>
    /// Model class For Reset password
    /// </summary>
   public class ResetPassword
    {
        public string UserEmail { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Common.Dto.Base;

namespace CoreApp.Data.Dto.Request.Authentication
{
    public class LoginRequest:BaseRequest
    {
        [DefaultValue("adminhrm")]
        public string UserName { get; set; }

        [DefaultValue("123456")]
        public string PassWord { get; set; }
    }
}

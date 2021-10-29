using System;
using System.Collections.Generic;
using System.Text;
using Common.Dto.Base;
using CoreApp.Data.Dto.Dto;

namespace CoreApp.Data.Dto.Response.Authentication
{
    public class LoginResponse :BaseResponse<AdminDTO>
    {
        public string Token { get; set; }
        public string Role { get; set; }
       
    }
}

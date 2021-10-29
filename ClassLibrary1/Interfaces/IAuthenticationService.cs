using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoreApp.Data.Dto.Request.Authentication;
using CoreApp.Data.Dto.Response.Authentication;

namespace CoreApp.Service.Interfaces
{
    public interface IAuthenticationService
    {

        public Task<LoginResponse> Login(LoginRequest request);

    }
}

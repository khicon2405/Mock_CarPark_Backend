using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;


/*using CoreAppData.Entity;*/
using CoreApp.Service.Interfaces;
using CoreApp.Service.Implements;
using AutoMapper;
using CoreApp.Data.Dto.Response.Authentication;
using CoreApp.Data.Dto.Request.Authentication;

namespace App_Demo.Controllers
{
    [Authorize]


    [Route("[controller]/[action]")]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        public AuthenticationController(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<LoginResponse> Login([FromBody] LoginRequest request)
        {
            return await _authenticationService.Login(request).ConfigureAwait(false);
        }

    }
}

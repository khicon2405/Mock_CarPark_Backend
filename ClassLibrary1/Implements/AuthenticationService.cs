using AutoMapper;
using CoreApp.Data.Constant;
using CoreApp.Data.Dto.Dto;
using CoreApp.Data.Dto.Request.Authentication;
using CoreApp.Data.Dto.Response.Authentication;
using CoreApp.Data.Entity;
using CoreApp.Data.Repository;
using CoreApp.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Service.Implements
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        private IGenericRepository<Admin> _adminRepository;
        private IConfiguration _configuration;
        private IMapper _mapper;

        public AuthenticationService(IGenericRepository<Admin> adminRepository, IConfiguration configuration, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            LoginResponse response = new LoginResponse(); ;
            var hasher = new PasswordHasher<Admin>();
            try
            {
                var adminDb = _adminRepository.FindByCondition(
                    item => item.Account == request.UserName).FirstOrDefault();
                if (adminDb != null)
                {
                    if (hasher.VerifyHashedPassword(null, adminDb.Password, request.PassWord) == PasswordVerificationResult.Failed)
                    {
                        response.Errors = ERROR_RESPONSE.LOGIN_ERROR_RESPONSE;
                        return response;
                    }

                    response.Token = generateJwtToken(adminDb);
                    response.Data = _mapper.Map<AdminDTO>(adminDb);
                    response.Success = true;
                }
                else
                {
                    response.Errors = ERROR_RESPONSE.LOGIN_ERROR_RESPONSE;
                }
                return response;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return response;
            }
        }

        private string generateJwtToken(Admin admin)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, admin.Account),
               new Claim(ClaimTypes.NameIdentifier, admin.AdminId.ToString()),
               new Claim(ClaimTypes.Role, admin.Department)
            };

            var tokenKey = _configuration["TokenKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var expires = DateTime.UtcNow.AddHours(2);

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return tokenHandler.WriteToken(token);
        }
    }
}





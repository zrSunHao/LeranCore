using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.System.Auth.Accounts.Dto;
using Sun.DatingApp.Model.System.Auth.Accounts.Model;
using Sun.DatingApp.Model.System.Auth.Login.Dto;
using Sun.DatingApp.Model.System.Auth.Login.Model;
using Sun.DatingApp.Model.System.Auth.Register.Dto;
using Sun.DatingApp.Services.Services.System.AuthServices;

namespace Sun.DatingApp.Api.Controllers.System
{
    /// <summary>
    /// 认证
    /// </summary>
    public class AuthController : BaseController
    {
        private readonly IAuthService _service;
        private readonly IConfiguration _config;

        public AuthController(IAuthService service,IConfiguration config)
        {
            _service = service;
            _config = config;
            //_service.SetCurrentUserId(CurrentUserId);
        }


        [HttpGet("test")]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok("This is datingApp Api!");
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<WebApiResult> Register([FromBody]RegisterDto dto)
        {
            return await _service.Register(dto);
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<WebApiResult<AccessDataModel>> Login(LoginDto dto)
        {
            var result = new WebApiResult<AccessDataModel>();
            try
            {
                result = await _service.Login(dto.Email, dto.Password);
                if (!result.Success)
                {
                    return result;
                }

                var model = result.Data;

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),
                        new Claim(ClaimTypes.Name, model.UserName),
                        new Claim(ClaimTypes.Email, model.Email),
                        new Claim(ClaimTypes.Role, model.Role),
            }),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature)
                };
                var accessToken = tokenHandler.CreateToken(tokenDescriptor);
                var accessTokenString = tokenHandler.WriteToken(accessToken);

                model.AccessToken = accessTokenString;
                result.Data = model;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.AddError("出现异常，请联系管理员");
            }
            return result;
        }

        /// <summary>
        /// 刷新Token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<WebApiResult<AccessDataModel>> Refresh(Guid refreshToken)
        {
            var result = new WebApiResult<AccessDataModel>();
            try
            {
                result = await _service.Refresh(refreshToken);
                if (!result.Success)
                {
                    return result;
                }

                var model = result.Data;

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),
                        new Claim(ClaimTypes.Name, model.UserName),
                        new Claim(ClaimTypes.Email, model.Email),
                        new Claim(ClaimTypes.Role, model.Role),
                    }),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature)
                };
                var accessToken = tokenHandler.CreateToken(tokenDescriptor);
                var accessTokenString = tokenHandler.WriteToken(accessToken);

                model.AccessToken = accessTokenString;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.AddError("出现异常，请联系管理员");
            }
            return result;
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("logout")]
        public async Task<WebApiResult> Logout(Guid id)
        {
            return await _service.Logout(id);
        }

        /// <summary>
        /// 账号管理列表数据
        /// </summary>
        /// <param name="opt"></param>
        /// <returns></returns>
        [HttpPost("accounts")]
        public async Task<WebApiPagingResult<List<AccountListModel>>> Accounts(PagingOptions<AccountListQueryDto> opt)
        {
            return await _service.Accounts(opt);
        }

    }
}

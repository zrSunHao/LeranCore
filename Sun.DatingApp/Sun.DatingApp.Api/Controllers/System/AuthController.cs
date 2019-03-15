using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Common.Dto;
using Sun.DatingApp.Model.System.Auth.Accounts.Dto;
using Sun.DatingApp.Model.System.Auth.Accounts.Model;
using Sun.DatingApp.Model.System.Auth.Info;
using Sun.DatingApp.Model.System.Auth.Login.Dto;
using Sun.DatingApp.Model.System.Auth.Login.Model;
using Sun.DatingApp.Model.System.Auth.Register.Dto;
using Sun.DatingApp.Services.Services.System.AuthServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sun.DatingApp.Api.Controllers.System
{
    /// <summary>
    /// 认证
    /// </summary>
    public class AuthController : BaseController
    {
        private readonly IAuthService _service;
        private readonly IConfiguration _config;

        public AuthController(IAuthService service, IConfiguration config)
        {
            _service = service;
            _config = config;
            //_service.SetCurrentUserId(CurrentUserId);
        }

        /// <summary>
        /// 测试匿名链接时Api是否正常
        /// </summary>
        /// <returns></returns>
        [HttpGet("TestAnonymousLink")]
        [AllowAnonymous]
        public IActionResult TestAnonymousLink()
        {
            return Ok("This is DatingApp Api,Anonymous Link Normal!");
        }

        /// <summary>
        /// 测试认证链接时Api是否正常
        /// </summary>
        /// <returns></returns>
        [HttpGet("TestAuthorizationLink")]
        [AllowAnonymous]
        public IActionResult TestAuthorizationLink()
        {
            return Ok("This is DatingApp Api,Authorization Link Normal!");
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("Register")]
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
        [HttpPost("Login")]
        public async Task<WebApiResult<AccountInfo>> Login(LoginDto dto)
        {
            var result = new WebApiResult<AccountInfo>();
            try
            {
                result = await _service.Login(dto.Email, dto.Password);
                if (!result.Success)
                {
                    return result;
                }

                var info = result.Data;
                var nickName = string.IsNullOrEmpty(info.Name) ? "" : info.Name;

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, info.Id.ToString()),
                        new Claim(ClaimTypes.Name, nickName),
                        new Claim(ClaimTypes.Email, info.Email),
                        new Claim(ClaimTypes.Role, info.RoleId.ToString()),
            }),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature)
                };
                var accessToken = tokenHandler.CreateToken(tokenDescriptor);
                var accessTokenString = tokenHandler.WriteToken(accessToken);

                info.AccessToken = accessTokenString;
                result.Data = info;
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
        [HttpPost("Refresh")]
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
        [HttpGet("Logout")]
        public async Task<WebApiResult> Logout(Guid id)
        {
            return await _service.Logout(id);
        }



        /// <summary>
        /// 账号管理列表数据
        /// </summary>
        /// <param name="opt"></param>
        /// <returns></returns>
        [HttpPost("Accounts")]
        public async Task<WebApiPagingResult<List<AccountListModel>>> Accounts(PagingOptions<AccountListQueryDto> opt)
        {
            return await _service.Accounts(opt);
        }

        /// <summary>
        /// 新建账号
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("CreateAccount")]
        public async Task<WebApiResult> CreateAccount(EditAccountDto dto)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.CreateAccount(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 编辑账号
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("EditAccount")]
        public async Task<WebApiResult> EditAccount(EditAccountDto dto)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.EditAccount(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 批量编辑
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("BatchEditAccount")]
        public async Task<WebApiResult> BatchEditAccount(BatchEditAccountDto dto)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.BatchEditAccount(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 启用或禁用账号
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("ActiveAccount")]
        public async Task<WebApiResult> ActiveAccount(ActiveDto dto)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.ActiveAccount(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 锁定账号
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("LockoutAccount")]
        public async Task<WebApiResult> LockoutAccount(LockoutAccountDto dto)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.LockoutAccount(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 删除账号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("DeleteAccount")]
        public async Task<WebApiResult> DeleteAccount(Guid id)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.DeleteAccount(id, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("BatchDeleteAccount")]
        public async Task<WebApiResult> BatchDeleteAccount(BatchDeleteAccountDto dto)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.BatchDeleteAccount(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }



        /// <summary>
        /// 获取账号信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetAccountInfo")]
        public async Task<WebApiResult<AccountInfo>> GetAccountInfo(Guid id)
        {
            return await _service.GetAccountInfo(id);
        }

        /// <summary>
        /// 获取该账号的菜单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetAccountMenu")]
        public async Task<WebApiResult<AccountMenuInfo>> GetAccountMenu(Guid id)
        {
            return await _service.GetAccountMenu(id);
        }

        /// <summary>
        /// 获取该账号的权限信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetAccountPermission")]
        public async Task<WebApiResult<string[]>> GetAccountPermission(Guid id)
        {
            return await _service.GetAccountPermission(id);
        }
    }
}

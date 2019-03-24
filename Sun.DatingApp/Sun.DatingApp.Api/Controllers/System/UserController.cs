using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.System.Users.Dto;
using Sun.DatingApp.Model.System.Users.Model;
using Sun.DatingApp.Services.Services.System.UserServices;

namespace Sun.DatingApp.Api.Controllers.System
{
    public class UserController : BaseController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
            _service.SetCurrentUserId(CurrentUserId);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUserInfo")]
        public async Task<WebApiResult<UserInfoModel>> GetUserInfo()
        {
            var result = new WebApiResult<UserInfoModel>();
            if (CurrentUserId.HasValue)
            {
                result = await _service.GetUserInfo(CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpPost("EditUserInfo")]
        public async Task<WebApiResult> EditUserInfo(UserInfoDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.EditUserInfo(dto,CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        [HttpPost("Test")]
        public WebApiResult Test()
        {
            return _service.Test();
        }
    }
}
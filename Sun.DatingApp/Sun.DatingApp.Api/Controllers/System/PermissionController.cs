using Microsoft.AspNetCore.Mvc;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Common.Dto;
using Sun.DatingApp.Model.System.Permissions.Dto;
using Sun.DatingApp.Model.System.Permissions.Model;
using Sun.DatingApp.Services.Services.System.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sun.DatingApp.Api.Extensions.Authorization;

namespace Sun.DatingApp.Api.Controllers.System
{
    public class PermissionController : BaseController
    {
        public IPermissionService _service;

        public PermissionController(IPermissionService service)
        {
            _service = service;
        }

        /// <summary>
        /// 获取对应模块下的操作权限
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPermission")]
        public WebApiResult<List<PermissionListModel>> GetPermission(Guid id)
        {
            return  _service.GetPermission(id);
        }

        /// <summary>
        /// 新建权限
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("CreatePermission")]
        public async Task<WebApiResult<PermissionListModel>> CreatePermission(PermissionEditDto dto)
        {
            var result = new WebApiResult<PermissionListModel>();
            if (CurrentUserId.HasValue)
            {
                result = await _service.CreatePermission(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("EditPermission")]
        public async Task<WebApiResult> EditPermission(PermissionEditDto dto)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.EditPermission(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("DeletePermission")]
        [PermissionFilter(Permissions.DeletePermission)]
        public async Task<WebApiResult> DeletePermission(Guid id)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.DeletePermission(id, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 权限开启或关闭
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("ActivePermission")]
        public async Task<WebApiResult> ActivePermission(ActiveDto dto)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.ActivePermission(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }
    }
}
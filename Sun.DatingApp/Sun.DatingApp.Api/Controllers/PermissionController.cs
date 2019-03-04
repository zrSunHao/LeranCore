using Microsoft.AspNetCore.Mvc;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Permissions.Dto;
using Sun.DatingApp.Model.Permissions.Model;
using Sun.DatingApp.Services.Services.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sun.DatingApp.Api.Controllers
{
    public class PermissionController : BaseController
    {
        public IPermissionService _service;

        public PermissionController(IPermissionService service)
        {
            _service = service;
        }

        /// <summary>
        /// 获取权限树数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("getpermissions")]
        public async Task<WebApiResult<List<PermissionListModel>>> GetPermissions()
        {
            return await _service.GetPermissions();
        }

        /// <summary>
        /// 新建权限树节点
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<WebApiResult<PermissionListModel>> Create(PermissionEditDto dto)
        {
            var result = new WebApiResult<PermissionListModel>();
            if (CurrentUserId.HasValue)
            {
                result = await _service.Create(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 修改权限节点
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("edit")]
        public async Task<WebApiResult> Edit(PermissionEditDto dto)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.Edit(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 删除权限节点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("delete")]
        public async Task<WebApiResult> Delete(Guid id)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.Delete(id, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }
    }
}
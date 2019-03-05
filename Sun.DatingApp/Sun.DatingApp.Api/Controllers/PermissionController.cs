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
        /// 获取操作模块权限数据
        /// </summary>
        /// <returns></returns>
        [HttpPost("getmodulepermission")]
        public async Task<WebApiResult<List<PermissionListModel>>> GetModulePermission(string name)
        {
            return await _service.GetModulePermission(name);
        }

        /// <summary>
        /// 获取对应模块下的操作权限
        /// </summary>
        /// <returns></returns>
        [HttpGet("getoperatepermission")]
        public async Task<WebApiResult<List<PermissionListModel>>> GetOperatePermission(Guid id)
        {
            return await _service.GetOperatePermission(id);
        }

        /// <summary>
        /// 新建权限
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
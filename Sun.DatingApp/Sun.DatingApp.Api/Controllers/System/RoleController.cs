using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Common.Dto;
using Sun.DatingApp.Model.Common.Model;
using Sun.DatingApp.Model.System.Roles.Dto;
using Sun.DatingApp.Model.System.Roles.Model;
using Sun.DatingApp.Services.Services.System.RoleServices;

namespace Sun.DatingApp.Api.Controllers.System
{
    public class RoleController : BaseController
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("GetRoles")]
        public async Task<WebApiResult<List<RoleListModel>>> GetRoles(SearchRoleDto dto)
        {
            return await _service.GetRoles(dto);
        }

        /// <summary>
        /// 新建角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("CreateRole")]
        public async Task<WebApiResult> CreateRole(CreateOrEditRoleDto dto)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.CreateRole(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("EditRole")]
        public async Task<WebApiResult> EditRole(CreateOrEditRoleDto dto)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.EditRole(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 启用或禁用角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("ActiveRole")]
        public async Task<WebApiResult> ActiveRole(ActiveDto dto)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.ActiveRole(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet("DeleteRole")]
        public async Task<WebApiResult> DeleteRole(Guid roleId)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.DeleteRole(roleId, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }


        [HttpGet("GetRolePermissions")]
        public async Task<WebApiResult<List<RolePageModel>>> GetRolePermissions(Guid id)
        {
            return await _service.GetRolePermissions(id);
        }

        /// <summary>
        /// 修改角色权限
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("EditRolePermission")]
        public async Task<WebApiResult> EditRolePermission(EditRolePermissionDto dto)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.EditRolePermission(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }


        
        /// <summary>
        /// 获取角色选择列表数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetRoleItems")]
        public async Task<WebApiResult<List<ItemModel>>> GetRoleItems()
        {
            return await _service.GetRoleItems();
        }
    }
}
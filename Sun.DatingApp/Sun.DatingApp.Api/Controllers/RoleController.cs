using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Roles.Dto;
using Sun.DatingApp.Model.Roles.Model;
using Sun.DatingApp.Services.Services.RoleServices;

namespace Sun.DatingApp.Api.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        /// <summary>
        /// 修改角色权限
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("updateRolePermission")]
        public async Task<WebApiResult> UpdateRolePermission(UpdateRolePermissionDto dto)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result =  await _service.UpdateRolePermission(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        [HttpPost("getroles")]
        public async Task<WebApiResult<List<RoleListModel>>> GetRoles(SearchRoleDto dto)
        {
            return await _service.GetRoles(dto);
        }
    }
}
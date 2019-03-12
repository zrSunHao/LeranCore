using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Common.Model;
using Sun.DatingApp.Model.System.Roles.Dto;
using Sun.DatingApp.Model.System.Roles.Model;

namespace Sun.DatingApp.Services.Services.System.RoleServices
{
    public interface IRoleService
    {
        Task<WebApiResult> EditRolePermission(EditRolePermissionDto dto, Guid accountId);

        Task<WebApiResult> CreateRole(CreateOrUpdateRoleDto dto, Guid accountId);

        Task<WebApiResult> UpdateRole(CreateOrUpdateRoleDto dto, Guid accountId);

        Task<WebApiResult> DeleteRole(Guid roleId, Guid accountId);

        Task<WebApiResult<List<RoleListModel>>> GetRoles(SearchRoleDto dto);

        Task<WebApiResult<List<RolePageModel>>> GetRolePermissions(Guid id);

        Task<WebApiResult<List<ItemModel>>> GetRoleItems();
    }
}

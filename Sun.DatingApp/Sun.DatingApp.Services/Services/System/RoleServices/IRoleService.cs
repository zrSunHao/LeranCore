﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Common.Dto;
using Sun.DatingApp.Model.Common.Model;
using Sun.DatingApp.Model.System.Roles.Dto;
using Sun.DatingApp.Model.System.Roles.Model;

namespace Sun.DatingApp.Services.Services.System.RoleServices
{
    public interface IRoleService
    {
        WebApiPagingResult<List<RoleListModel>> GetRoles(PagingOptions<SearchRoleDto> paging);

        Task<WebApiResult> CreateRole(CreateOrEditRoleDto dto, Guid accountId);

        Task<WebApiResult> EditRole(CreateOrEditRoleDto dto, Guid accountId);

        Task<WebApiResult> ActiveRole(ActiveDto dto, Guid accountId);

        Task<WebApiResult> DeleteRole(Guid roleId, Guid accountId);

        

        Task<WebApiResult<List<RolePageModel>>> GetRolePermissions(Guid id, Guid accountId);

        Task<WebApiResult> EditRolePermission(EditRolePermissionDto dto, Guid accountId);



        Task<WebApiResult<List<ItemModel>>> GetRoleItems();
    }
}

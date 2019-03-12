using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Common.Dto;
using Sun.DatingApp.Model.Common.Model;
using Sun.DatingApp.Model.System.Permissions.Dto;
using Sun.DatingApp.Model.System.Permissions.Model;

namespace Sun.DatingApp.Services.Services.System.Permissions
{
    public interface IPermissionService
    {
        /// <summary>
        /// 获取对应模块下的操作权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<WebApiResult<List<PermissionListModel>>> GetPermission(Guid id);

        /// <summary>
        /// 新建权限树节点
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<WebApiResult<PermissionListModel>> CreatePermission(PermissionEditDto dto, Guid accountId);

        /// <summary>
        /// 修改权限节点
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<WebApiResult> EditPermission(PermissionEditDto dto, Guid accountId);

        /// <summary>
        /// 删除权限节点
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<WebApiResult> DeletePermission(Guid id, Guid accountId);

        /// <summary>
        /// 权限启用或关闭
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<WebApiResult> ActivePermission(ActiveDto dto,Guid accountId);

    }
}

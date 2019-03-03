﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Permissions.Dto;
using Sun.DatingApp.Model.Permissions.Model;

namespace Sun.DatingApp.Services.Services.Permissions
{
    public interface IPermissionService
    {
        /// <summary>
        /// 获取权限树数据
        /// </summary>
        /// <returns></returns>
        Task<WebApiResult<List<PermissionTreeModel>>> GetPermissions();

        /// <summary>
        /// 新建权限树节点
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<WebApiResult<PermissionTreeModel>> Create(PermissionEditDto dto, Guid accountId);

        /// <summary>
        /// 修改权限节点
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<WebApiResult> Edit(PermissionEditDto dto, Guid accountId);

        /// <summary>
        /// 删除权限节点
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<WebApiResult> Delete(Guid id, Guid accountId);
    }
}
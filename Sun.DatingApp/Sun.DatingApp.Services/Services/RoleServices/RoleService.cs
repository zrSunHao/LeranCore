using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Model.Auth.Login.Model;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Roles.Dto;
using Sun.DatingApp.Services.Services.BaseServices;
using Sun.DatingApp.Utility.CacheUtility;

namespace Sun.DatingApp.Services.Services.RoleServices
{
    public class RoleService: BaseService,IRoleService
    {
        public RoleService(DataContext dataContext, IMapper mapper, ICacheService catchService) : base(dataContext, mapper, catchService)
        {
        }

        /// <summary>
        /// 修改账号所属角色
        /// </summary>
        /// <param name="newRoleId">新角色Id</param>
        /// <param name="accountId">当前账号Id</param>
        /// <returns></returns>
        public async Task<WebApiResult> UpdateAccountRole(Guid newRoleId,Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var account = await _dataContext.Accounts.FirstOrDefaultAsync(x => x.Id == accountId);
                account.RoleId = newRoleId;
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result.AddError(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 修改角色权限
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<WebApiResult> UpdateRolePermission(UpdateRolePermissionDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var allPermissions = await _dataContext.RolePermissions.Where(x => x.RoleId == dto.RoleId).ToListAsync();
                var dataPermissions = allPermissions;

                if (allPermissions.Any())
                {
                    var deleteIds = allPermissions.Where(x => !dto.PermissionNames.Contains(x.PermissionName)).Select(x => x.Id)
                        .ToList();
                    if (deleteIds.Any())
                    {
                        await _dataContext.RolePermissions.Where(x => deleteIds.Contains(x.Id)).ForEachAsync(x =>
                        {
                            x.Deleted = false;
                            x.DeletedAt = DateTime.Now;
                            x.DeletedById = accountId;
                        });
                    }

                    dataPermissions = allPermissions.Where(x => dto.PermissionNames.Contains(x.PermissionName)).ToList();
                }

                var dataPermissionNames = dataPermissions.Select(x => x.PermissionName).ToList();
                var newPermissionNames = dto.PermissionNames.Where(x => !dataPermissionNames.Contains(x)).ToList();
                if (newPermissionNames.Any())
                {
                    var entitys = new List<RolePermission>();
                    foreach (var newPermissionName in newPermissionNames)
                    {
                        var entity = new RolePermission
                        {
                            Id = Guid.NewGuid(),
                            RoleId = dto.RoleId,
                            PermissionName = newPermissionName,
                            Deleted = false,
                            CreatedAt = DateTime.Now,
                            CreatedById = accountId,
                        };
                        entitys.Add(entity);
                    }

                    await _dataContext.RolePermissions.AddRangeAsync(entitys);
                }

                await _dataContext.SaveChangesAsync();

                var account = _catchService.Get<AccessDataModel>(accountId.ToString());
                account.Permissions = dto.PermissionNames;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result.AddError(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 新建角色
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<WebApiResult> CreateRole(CreateOrUpdateRoleDto dto,Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var role = new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    Code = dto.Code,
                    Intro = dto.Intro,
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    CreatedById = accountId,
                };
                _dataContext.Roles.Add(role);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result.AddError(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<WebApiResult> UpdateRole(CreateOrUpdateRoleDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result.AddError(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<WebApiResult> DeleteRole(Guid roleId, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result.AddError(ex.Message);
            }
            return result;
        }
    }
}

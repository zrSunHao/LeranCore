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
using Sun.DatingApp.Model.Permissions.Model;
using Sun.DatingApp.Model.Roles.Dto;
using Sun.DatingApp.Model.Roles.Model;
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
                if (!dto.Id.HasValue)
                {
                    result.AddError("数据为空");
                    return result;
                }

                var role = await _dataContext.Roles.FirstOrDefaultAsync(x => x.Id == dto.Id.Value);
                if (role == null)
                {
                    result.AddError("数据为空");
                    return result;
                }

                role.Code = dto.Code;
                role.Name = dto.Name;
                role.Intro = dto.Intro;
                role.UpdatedAt = DateTime.Now;
                role.UpdatedById = accountId;

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
                var role = await _dataContext.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
                if (role == null)
                {
                    result.AddError("数据为空");
                    return result;
                }

                role.Deleted = true;
                role.DeletedAt = DateTime.Now;
                role.DeletedById = accountId;

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
        /// 获取角色列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<WebApiResult<List<RoleListModel>>> GetRoles(SearchRoleDto dto)
        {
            var result = new WebApiResult<List<RoleListModel>>();
            try
            {
                var datas = await _dataContext.Roles.Select(x => new RoleListModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    Active = x.Active,
                    Intro = x.Intro,
                }).ToListAsync();
                
                if (datas.Any())
                {
                    var roleIds = datas.Select(x => x.Id).ToList();

                    var modules = await (from rp in _dataContext.RolePermissions
                        join p in _dataContext.Permissions on rp.RoleId equals p.Id into tp
                        from prp in tp.DefaultIfEmpty()
                        where roleIds.Contains(rp.RoleId) && !rp.Deleted
                        select new RoleListPermissionModel
                        {
                            Id = prp.Id,
                            Name = prp.Name,
                            Icon = prp.Icon,
                            TagColor = prp.Active ? prp.TagColor : "",
                            RoleId = rp.RoleId
                        }).ToListAsync();

                    if (modules.Any())
                    {
                        foreach (var data in datas)
                        {
                            data.Modules = modules.Where(x => x.RoleId == data.Id).ToList();
                        }
                    }
                }

                result.Data = datas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result.AddError(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 修改账号所属角色
        /// </summary>
        /// <param name="newRoleId">新角色Id</param>
        /// <param name="accountId">当前账号Id</param>
        /// <returns></returns>
        public async Task<WebApiResult> UpdateAccountRole(Guid newRoleId, Guid accountId)
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
        /// 获取角色权限数据
        /// </summary>
        /// <returns></returns>
        public async Task<WebApiResult<List<RolePermissionModel>>> GetRolePermissions(Guid id)
        {
            var result = new WebApiResult<List<RolePermissionModel>>();
            try
            {
                var datas = new List<RolePermissionModel>();

                var rolePermissions = await this.GetRolePerssionEntitys(id);
                var rolePermissionIds = rolePermissions.Select(x => x.PermissionId).ToList();

                var permissionEntitys = await this.GetPerssionEntitys();
                var parents = permissionEntitys.Where(x => !x.ParentId.HasValue).ToList();

                foreach (var parent in parents)
                {
                    var parentModel = new RolePermissionModel
                    {

                        Id = parent.Id,
                        Name = parent.Name,
                        Icon = parent.Icon,
                        Code = parent.Code,
                        Intro = parent.Intro,
                        Checked = rolePermissionIds.Contains(parent.Id)
                    };

                    var childrenDatas = new List<RolePermissionModel>();
                    var childrens = permissionEntitys.Where(x => x.ParentId == parent.Id);
                    foreach (var children in childrens)
                    {
                        var childrenModel = new RolePermissionModel
                        {
                            Id = parent.Id,
                            Name = parent.Name,
                            Icon = parent.Icon,
                            Code = parent.Code,
                            Intro = parent.Intro,
                            ParentId = parent.ParentId,
                            Checked = rolePermissionIds.Contains(children.Id)
                        };
                        childrenDatas.Add(childrenModel);
                    }

                    if (childrenDatas.Any())
                    {
                        parentModel.Children = childrenDatas;
                    }

                    datas.Add(parentModel);
                }
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
                var allPermissions = await _dataContext.RolePermissions.Where(x => x.RoleId == dto.RoleId && !x.Deleted).ToListAsync();
                var dataPermissions = allPermissions;
                var dtoPermissionIds = dto.Permissions.Select(x => x.Id).ToList();

                if (allPermissions.Any())
                {
                    var deleteIds = allPermissions.Where(x => !dtoPermissionIds.Contains(x.Id)).Select(x => x.Id)
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

                    dataPermissions = allPermissions.Where(x => dtoPermissionIds.Contains(x.Id)).ToList();
                }

                var dataPermissionIds = dataPermissions.Select(x => x.Id).ToList();
                var newRolePermissions = dto.Permissions.Where(x => !dataPermissionIds.Contains(x.Id)).ToList();
                if (newRolePermissions.Any())
                {
                    var entitys = new List<RolePermission>();
                    foreach (var newRolePermission in newRolePermissions)
                    {
                        var entity = new RolePermission
                        {
                            Id = Guid.NewGuid(),
                            RoleId = dto.RoleId,
                            PermissionId = newRolePermission.Id,
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
                account.Permissions = dto.Permissions.Select(x=>x.Name).ToList();
                _catchService.Replace(accountId.ToString(), account);
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

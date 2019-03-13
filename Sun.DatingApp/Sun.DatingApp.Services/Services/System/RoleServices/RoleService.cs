using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Common.Dto;
using Sun.DatingApp.Model.Common.Model;
using Sun.DatingApp.Model.System.Roles.Dto;
using Sun.DatingApp.Model.System.Roles.Model;
using Sun.DatingApp.Services.Services.Common.BaseServices;
using Sun.DatingApp.Utility.CacheUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sun.DatingApp.Model.System.Menus.Model;

namespace Sun.DatingApp.Services.Services.System.RoleServices
{
    public class RoleService: BaseService,IRoleService
    {
        public RoleService(DataContext dataContext, IMapper mapper, ICacheHandler catchHandler) : base(dataContext, mapper, catchHandler)
        {
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
                var roles = await _dataContext.Roles.Select(x => new RoleListModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    Active = x.Active,
                    Intro = x.Intro,
                }).ToListAsync();

                if (roles.Any())
                {
                    var roleIds = roles.Select(x => x.Id).ToList();

                    var pages = await (from rp in _dataContext.RolePages
                        join p in _dataContext.Pages on rp.PageId equals p.Id into tp
                        from rrp in tp.DefaultIfEmpty()
                        where roleIds.Contains(rp.RoleId)
                        where !rp.Deleted
                        select new PageItem
                        {
                            Id = rrp.Id,
                            Name = rrp.Name,
                            Icon = rrp.Icon,
                            TagColor = rrp.TagColor,
                            Active = rrp.Active,
                            RoleId = rp.RoleId
                        }).ToListAsync();

                    if (pages.Any())
                    {
                        foreach (var role in roles)
                        {
                            role.Pages = pages.Where(x => x.RoleId == role.Id).ToList();
                        }
                    }
                }

                result.Data = roles;
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
        public async Task<WebApiResult> CreateRole(CreateOrEditRoleDto dto,Guid accountId)
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
        public async Task<WebApiResult> EditRole(CreateOrEditRoleDto dto, Guid accountId)
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
        /// 启用或禁用角色
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<WebApiResult> ActiveAccount(ActiveDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var entity = await _dataContext.Roles.FirstOrDefaultAsync(x => x.Id == dto.Id);
                if (entity == null)
                {
                    result.AddError("数据为空");
                    return result;
                }

                if (dto.Active == entity.Active)
                {
                    var errMsg = "";
                    if (entity.Active) errMsg = "角色早已开启"; else errMsg = "角色早已关闭";
                    result.AddError(errMsg);
                    return result;
                }

                entity.Active = dto.Active;
                entity.UpdatedAt = DateTime.Now;
                entity.UpdatedById = accountId;

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>+
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
        /// 获取角色权限数据
        /// </summary>
        /// <returns></returns>
        public async Task<WebApiResult<List<RolePageModel>>> GetRolePermissions(Guid id)
        {
            var result = new WebApiResult<List<RolePageModel>>();
            try
            {
                var pages = await (from p in _dataContext.Pages
                    join m in _dataContext.Menus on p.MenuId equals m.Id into tm
                    from mp in tm.DefaultIfEmpty()
                    where !p.Deleted
                    select new RolePageModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        MenuName = mp.Name,
                        MenuTagColor = mp.TagColor,
                        MenuIcon = mp.Icon,
                        TagColor = p.TagColor,
                        Icon = p.Icon,
                        Active = p.Active
                    }).ToListAsync();

                if (pages.Any())
                {
                    var allPermissions = await _dataContext.Permissions.Where(x => !x.Deleted).ToListAsync();
                    var rolePermissionIds = await _dataContext.RolePermissions.Where(x => x.RoleId == id && !x.Deleted)
                        .Select(x => x.PermissionId).ToListAsync();

                    foreach (var page in pages)
                    {
                        page.Permissions = allPermissions.Where(x => x.PageId == page.Id).Select(x =>
                            new RolePermissionModel
                            {
                                Id = x.Id,
                                Name = x.Name,
                                Active = x.Active,
                                Icon = x.Icon,
                                Code = x.Code,
                                Intro = x.Intro,
                                PageId = x.PageId,
                                Checked = rolePermissionIds.Contains(x.Id)
                            }).ToList();
                    }
                }

                result.Data = pages;
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
        public async Task<WebApiResult> EditRolePermission(EditRolePermissionDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var deletePages = await _dataContext.RolePages.Where(x => x.RoleId == dto.RoleId).ToListAsync();
                _dataContext.RolePages.RemoveRange(deletePages);

                var deletePermissions = await _dataContext.RolePermissions.Where(x => x.RoleId == dto.RoleId).ToListAsync();
                _dataContext.RolePermissions.RemoveRange(deletePermissions);

                await _dataContext.SaveChangesAsync();


                if (dto.PageIds != null && dto.PageIds.Any())
                {
                    var pages = new List<RolePage>();
                    foreach (var pageId in dto.PageIds)
                    {
                        var page = new RolePage
                        {
                            Id = Guid.NewGuid(),
                            RoleId = dto.RoleId,
                            PageId = pageId,
                            CreatedAt = DateTime.Now,
                            CreatedById = accountId,
                            Deleted = false
                        };
                        pages.Add(page);
                    }
                    _dataContext.RolePages.AddRange(pages);
                }

                if (dto.PermissionAndPageIds != null && dto.PermissionAndPageIds.Any())
                {
                    var permissions = new List<RolePermission>();
                    foreach (var permissionAndPageId in dto.PermissionAndPageIds)
                    {
                        var permission = new RolePermission
                        {
                            Id = Guid.NewGuid(),
                            RoleId = dto.RoleId,
                            PermissionId = permissionAndPageId.PermissionId,
                            PageId = permissionAndPageId.PageId,
                            CreatedAt = DateTime.Now,
                            CreatedById = accountId,
                            Deleted = false
                        };
                        permissions.Add(permission);
                    }
                    _dataContext.RolePermissions.AddRange(permissions);
                }

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
        /// <returns></returns>
        public async Task<WebApiResult<List<ItemModel>>> GetRoleItems()
        {
            var result = new WebApiResult<List<ItemModel>>();
            try
            {
                var data = await _dataContext.Roles.Where(x => !x.Deleted).Select(x =>
                    new ItemModel
                    {
                        Value = x.Id,
                        Label = x.Name
                    }).ToListAsync();

                result.Data = data;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }
    }
}

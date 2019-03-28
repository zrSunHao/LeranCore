using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Common.Dto;
using Sun.DatingApp.Model.Common.Model;
using Sun.DatingApp.Model.System.Menus.Model;
using Sun.DatingApp.Model.System.Roles.Dto;
using Sun.DatingApp.Model.System.Roles.Model;
using Sun.DatingApp.Services.Services.Common.BaseServices;
using Sun.DatingApp.Utility.CacheUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Sun.DatingApp.Data.View.System;

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
        /// <param name="paging"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public WebApiPagingResult<List<RoleListModel>> GetRoles(PagingOptions<SearchRoleDto> paging)
        {
            var result = new WebApiPagingResult<List<RoleListModel>>();
            try
            {
                var roleSql = @"SELECT * FROM [SystemRole] WHERE [Deleted] = N'0'";
                var entitis = _dapperContext.Conn.Query<SystemRole>(roleSql).ToList();
                if (!entitis.Any())
                {
                    return result;
                }

                var roles = _mapper.Map<List<SystemRole>, List<RoleListModel>>(entitis);
                if (roles.Any())
                {
                    var pageSql = @"SELECT * FROM [ViewRolePageList]";
                    var views = _dapperContext.Conn.Query<ViewRolePageList>(pageSql).ToList();
                    if (!views.Any())
                    {
                        result.Data = roles;
                        return result;
                    }

                    var pages = _mapper.Map<List<ViewRolePageList>, List<PageItem>>(views);
                    if (pages.Any())
                    {
                        foreach (var role in roles)
                        {
                            var names = pages.Where(x => x.RoleId == role.Id).OrderBy(x => x.Order).Select(x => x.Name)
                                .ToList();
                            role.PageNames = names.ToArray().Join("；"); 
                        }
                    }
                }

                var data = roles;

                if (paging.Filter != null && !string.IsNullOrEmpty(paging.Filter.Name))
                {
                    data = data.Where(x => x.Name.Contains(paging.Filter.Name)).ToList();
                }

                if (paging.Filter != null && !string.IsNullOrEmpty(paging.Filter.PageName))
                {
                    data = data.Where(x => x.PageNames.Contains(paging.Filter.PageName)).ToList();
                }

                result.RowsCount = data.Count();
                data = data.OrderBy(x => x.Rank).Skip(paging.PageIndex * paging.PageSize).Take(paging.PageSize).ToList();
                result.Data = data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result.AddError(ex.Message);
            }
            return result;
        }

        //TODO Rank
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
                var entity = _mapper.Map<CreateOrEditRoleDto, SystemRole>(dto);
                entity.CreatedById = accountId;

                _dataContext.SystemRoles.Add(entity);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result.AddError(ex.Message);
            }
            return result;
        }

        //TODO Rank
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

                var role = await _dataContext.SystemRoles.FirstOrDefaultAsync(x => x.Id == dto.Id.Value);
                if (role == null)
                {
                    result.AddError("数据为空");
                    return result;
                }

                role.Name = dto.Name;
                role.Intro = dto.Intro;
                role.Rank = dto.Rank;
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
        public async Task<WebApiResult> ActiveRole(ActiveDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var entity = await _dataContext.SystemRoles.FirstOrDefaultAsync(x => x.Id == dto.Id);
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
                var role = await _dataContext.SystemRoles.FirstOrDefaultAsync(x => x.Id == roleId);
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
        public async Task<WebApiResult<List<RolePageModel>>> GetRolePermissions(Guid id, Guid accountId)
        {
            var result = new WebApiResult<List<RolePageModel>>();
            try
            {
                var pageSql = @"SELECT * FROM [ViewPageList]";
                var views = _dapperContext.Conn.Query<ViewPageList>(pageSql).ToList();
                if (!views.Any())
                {
                    return result;
                }
                
                views = views.OrderBy(x => x.Order).ToList();
                var pages = _mapper.Map<List<ViewPageList>, List<RolePageModel>>(views);

                var accountInfo = this.GetUserInfo(accountId);
                if (accountInfo.RoleRank != 0)
                {
                    pages = pages.Where(x => x.Name != "菜单管理" && x.Name != "权限管理").ToList();
                }

                if (pages.Any())
                {
                    var allPermissions = await _dataContext.SystemPermissions.Where(x => !x.Deleted).ToListAsync();
                    var rolePermissionIds = await _dataContext.SystemRolePermissions.Where(x => x.RoleId == id && !x.Deleted)
                        .Select(x => x.PermissionId).ToListAsync();

                    foreach (var page in pages)
                    {
                        page.Permissions = allPermissions.Where(x => x.PageId == page.Id)
                            .OrderBy(x=>x.Rank)
                            .Select(x =>
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
                        page.Checked = page.Permissions.Any(x => x.Checked);
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
                var deletePermissions = await _dataContext.SystemRolePermissions.Where(x => x.RoleId == dto.RoleId).ToListAsync();
                _dataContext.SystemRolePermissions.RemoveRange(deletePermissions);
                await _dataContext.SaveChangesAsync();

                if (dto.Permissions != null && dto.Permissions.Any())
                {
                    var permissions = new List<SystemRolePermission>();
                    foreach (var permissionAndPageId in dto.Permissions)
                    {
                        var permission = new SystemRolePermission
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
                    _dataContext.SystemRolePermissions.AddRange(permissions);
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
                var data = await _dataContext.SystemRoles.Where(x => !x.Deleted).Select(x =>
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

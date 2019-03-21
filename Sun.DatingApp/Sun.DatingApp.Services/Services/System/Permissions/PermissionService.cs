using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Common.Dto;
using Sun.DatingApp.Model.System.Permissions.Dto;
using Sun.DatingApp.Model.System.Permissions.Model;
using Sun.DatingApp.Services.Services.Common.BaseServices;
using Sun.DatingApp.Utility.CacheUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sun.DatingApp.Services.Services.System.Permissions
{
    public class PermissionService: BaseService, IPermissionService
    {
        public PermissionService(DataContext dataContext, IMapper mapper, ICacheHandler catchHandler) : base(dataContext, mapper, catchHandler)
        {

        }

        public async Task<WebApiResult<List<PermissionListModel>>> GetPermission(Guid id)
        {
            var result = new WebApiResult<List<PermissionListModel>>();
            try
            {
                var datas = await (from p in _dataContext.SystemPermissions
                                   where p.PageId == id && !p.Deleted
                    select new PermissionListModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Active = p.Active,
                        Icon = p.Icon,
                        TagColor = p.TagColor,
                        Code = p.Code,
                        Intro = p.Intro,
                        PageId = p.PageId
                    }).ToListAsync();

                result.Data = datas;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        public async Task<WebApiResult<PermissionListModel>> CreatePermission(PermissionEditDto dto, Guid accountId)
        {
            var result = new WebApiResult<PermissionListModel>();
            try
            {
                var entity = new SystemPermission
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    Code = dto.Code,
                    Intro = dto.Intro,
                    Icon = dto.Icon,
                    TagColor = dto.TagColor,
                    PageId = dto.PageId,
                    Active = true,
                    CreatedAt = DateTime.Now,
                    CreatedById = accountId,
                    Deleted = false
                };

                _dataContext.SystemPermissions.Add(entity);

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result.AddError(ex.Message);
            }
            return result;
        }

        public async Task<WebApiResult> EditPermission(PermissionEditDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                if (!dto.Id.HasValue)
                {
                    result.AddError("Id不能为空");
                    return result;
                }

                var entity = await _dataContext.SystemPermissions.FirstOrDefaultAsync(x => x.Id == dto.Id.Value);
                if (entity == null)
                {
                    result.AddError("数据为空");
                    return result;
                }

                var exist = await _dataContext.SystemPermissions.AnyAsync(x => !x.Deleted && x.Id != dto.Id && x.Code == dto.Code);
                if (exist)
                {
                    result.AddError("存在相同的编号");
                    return result;
                }

                entity.Name = dto.Name;
                entity.Code = dto.Code;
                entity.Intro = dto.Intro;
                entity.Icon = dto.Icon;
                entity.TagColor = dto.TagColor;
                entity.UpdatedAt = DateTime.Now;
                entity.UpdatedById = accountId;

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result.AddError(ex.Message);
            }
            return result;
        }

        public async Task<WebApiResult> DeletePermission(Guid id, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var entity = await _dataContext.SystemPermissions.FirstOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                {
                    result.AddError("数据为空");
                    return result;
                }

                entity.Deleted = true;
                entity.DeletedAt = DateTime.Now;
                entity.DeletedById = accountId;

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result.AddError(ex.Message);
            }
            return result;
        }

        public async Task<WebApiResult> ActivePermission(ActiveDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var entity = await _dataContext.SystemPermissions.FirstOrDefaultAsync(x => x.Id == dto.Id);
                if (entity == null)
                {
                    result.AddError("数据为空");
                    return result;
                }

                if (dto.Active == entity.Active)
                {
                    var errMsg = "";
                    if (entity.Active) errMsg = "权限早已开启"; else errMsg = "权限早已关闭";
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
    }
}

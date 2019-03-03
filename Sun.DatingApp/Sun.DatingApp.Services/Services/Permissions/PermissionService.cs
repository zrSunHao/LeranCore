using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Permissions.Dto;
using Sun.DatingApp.Model.Permissions.Model;
using Sun.DatingApp.Services.Services.BaseServices;
using Sun.DatingApp.Utility.CacheUtility;

namespace Sun.DatingApp.Services.Services.Permissions
{
    public class PermissionService: BaseService, IPermissionService
    {
        public PermissionService(DataContext dataContext, IMapper mapper, ICacheService catchService) : base(dataContext, mapper, catchService)
        {

        }

        public async Task<WebApiResult<List<PermissionTreeModel>>> GetPermissions()
        {
            var result = new WebApiResult<List<PermissionTreeModel>>();
            try
            {
                var datas = new List<PermissionTreeModel>();

                var entitys = await this.GetPerssionEntitys();
                var parents = entitys.Where(x => !x.ParentId.HasValue).ToList();

                foreach (var parent in parents)
                {
                    var parentModel = new PermissionTreeModel
                    {

                        Key = parent.Id,
                        Title = parent.Name,
                        IsLeaf = true,
                        Icon = parent.Icon,
                        Code = parent.Code,
                        Intro = parent.Intro,
                    };

                    var childrenDatas = new List<PermissionTreeModel>();
                    var childrens = entitys.Where(x => x.ParentId == parent.Id);
                    foreach (var children in childrens)
                    {
                        var childrenModel = new PermissionTreeModel
                        {
                            Key = parent.Id,
                            Title = parent.Name,
                            IsLeaf = true,
                            Icon = parent.Icon,
                            Code = parent.Code,
                            Intro = parent.Intro,
                            ParentKey = parent.ParentId
                        };
                        childrenDatas.Add(childrenModel);
                    }

                    if (childrenDatas.Any())
                    {
                        parentModel.IsLeaf = false;
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

        public async Task<WebApiResult<PermissionTreeModel>> Create(PermissionEditDto dto, Guid accountId)
        {
            var result = new WebApiResult<PermissionTreeModel>();
            try
            {
                var entity = new Permission
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    Code = dto.Code,
                    Intro = dto.Intro,
                    Icon = dto.Icon,
                    CreatedAt = DateTime.Now,
                    CreatedById = accountId,
                    Deleted = false
                };
                _dataContext.Permissions.Add(entity);

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result.AddError(ex.Message);
            }
            return result;
        }

        public async Task<WebApiResult> Edit(PermissionEditDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                if (!dto.Id.HasValue)
                {
                    result.AddError("Id不能为空");
                    return result;
                }

                var entity = await _dataContext.Permissions.FirstOrDefaultAsync(x => x.Id == dto.Id.Value);
                if (entity == null)
                {
                    result.AddError("数据为空");
                    return result;
                }

                var exist = await _dataContext.Permissions.AnyAsync(x => !x.Deleted && x.Id != dto.Id && x.Code == dto.Code);
                if (exist)
                {
                    result.AddError("存在相同的编号");
                    return result;
                }

                entity.Name = dto.Name;
                entity.Code = dto.Code;
                entity.Intro = dto.Intro;
                entity.Icon = dto.Icon;
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

        public async Task<WebApiResult> Delete(Guid id, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var entity = await _dataContext.Permissions.FirstOrDefaultAsync(x => x.Id == id);
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
    }
}

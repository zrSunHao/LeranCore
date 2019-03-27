using AutoMapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Data.View.System;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Common.Dto;
using Sun.DatingApp.Model.Common.Model;
using Sun.DatingApp.Model.System.Menus.Dto;
using Sun.DatingApp.Model.System.Menus.Model;
using Sun.DatingApp.Services.Services.Common.BaseServices;
using Sun.DatingApp.Utility.CacheUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sun.DatingApp.Services.Services.System.MenuServices
{
    public class MenuService : BaseService, IMenuService
    {
        public MenuService(DataContext dataContext, IMapper mapper, ICacheHandler catchHandler) : base(dataContext, mapper, catchHandler)
        {
        }

        //TODO 分页
        public WebApiResult<List<MenuListModel>> GetMenus()
        {
            var result = new WebApiResult<List<MenuListModel>>();
            try
            {
                var sql = @"SELECT * FROM [SystemMenu] WHERE [Deleted] = N'0'";
                var entitis = _dapperContext.Conn.Query<SystemMenu>(sql).ToList();
                if (!entitis.Any())
                {
                    return result;
                }

                entitis = entitis.OrderBy(x => x.Order).ToList();
                var data = _mapper.Map<List<SystemMenu>, List<MenuListModel>>(entitis);
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        public async Task<WebApiResult> CreateMenu(MenuEditDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var entity = new SystemMenu
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    TagColor = dto.TagColor,
                    Icon = dto.Icon,
                    Active = true,
                    Intro = dto.Intro,
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    CreatedById = CurrentUserId
                };

                _dataContext.SystemMenus.Add(entity);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        public async Task<WebApiResult> EditMenu(MenuEditDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                if (!dto.Id.HasValue)
                {
                    result.AddError("数据不规范");
                    return result;
                }

                var entity = await _dataContext.SystemMenus.FirstOrDefaultAsync(x => x.Id == dto.Id.Value);
                if (entity == null)
                {
                    result.AddError("数据为空");
                    return result;
                }

                entity.Name = dto.Name;
                entity.TagColor = dto.TagColor;
                entity.Icon = dto.Icon;
                entity.Intro = dto.Intro;
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

        public async Task<WebApiResult> ActiveMenu(ActiveDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var entity = await _dataContext.SystemMenus.FirstOrDefaultAsync(x => x.Id == dto.Id);
                if (entity == null)
                {
                    result.AddError("数据为空");
                    return result;
                }

                if (dto.Active == entity.Active)
                {
                    var errMsg = "";
                    if (entity.Active) errMsg = "菜单早已开启"; else errMsg = "权限早已关闭";
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

        public async Task<WebApiResult> DeleteMenu(Guid id, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var entity = await _dataContext.SystemMenus.FirstOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                {
                    result.AddError("数据为空");
                    return result;
                }

                entity.Deleted = true;
                entity.DeletedAt = DateTime.Now;
                entity.DeletedById = accountId;

                await _dataContext.SystemPages.Where(x => x.MenuId == entity.Id).ForEachAsync(c =>
                {
                    c.Deleted = true;
                    c.DeletedAt = DateTime.Now;
                    c.DeletedById = accountId;
                });

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        //TODO 分页
        public WebApiResult<List<PageListModel>> GetPages(Guid id)
        {
            var result = new WebApiResult<List<PageListModel>>();
            try
            {
                var sql = @"SELECT TOP 1000 * FROM [dbo].[SystemPage] WHERE [MenuId] = @MenuId AND [Deleted] = N'0'";
                var entitis = _dapperContext.Conn.Query<SystemPage>(sql,new { MenuId = id }).ToList();
                if (!entitis.Any())
                {
                    return result;
                }

                var data = _mapper.Map<List<SystemPage>, List<PageListModel>>(entitis);
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        public async Task<WebApiResult> CreatePage(PageEditDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var entity = new SystemPage
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    Url = dto.Url,
                    TagColor = dto.TagColor,
                    Icon = dto.Icon,
                    Active = true,
                    Intro = dto.Intro,
                    MenuId = dto.MenuId,
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    CreatedById = CurrentUserId
                };

                _dataContext.SystemPages.Add(entity);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        public async Task<WebApiResult> EditPage(PageEditDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                if (!dto.Id.HasValue)
                {
                    result.AddError("数据不规范");
                    return result;
                }

                var entity = await _dataContext.SystemPages.FirstOrDefaultAsync(x => x.Id == dto.Id.Value);
                if (entity == null)
                {
                    result.AddError("数据为空");
                    return result;
                }

                entity.Name = dto.Name;
                entity.TagColor = dto.TagColor;
                entity.Url = dto.Url;
                entity.Icon = dto.Icon;
                entity.Intro = dto.Intro;
                entity.MenuId = dto.MenuId;
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

        public async Task<WebApiResult> ActivePage(ActiveDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var entity = await _dataContext.SystemPages.FirstOrDefaultAsync(x => x.Id == dto.Id);
                if (entity == null)
                {
                    result.AddError("数据为空");
                    return result;
                }

                if (dto.Active == entity.Active)
                {
                    var errMsg = "";
                    if (entity.Active) errMsg = "页面早已开启"; else errMsg = "权限早已关闭";
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

        public async Task<WebApiResult> DeletePage(Guid id, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var entity = await _dataContext.SystemPages.FirstOrDefaultAsync(x => x.Id == id);
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
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        public async Task<WebApiResult<List<ItemModel>>> GetPageItems()
        {
            var result = new WebApiResult<List<ItemModel>>();
            try
            {
                var data = await _dataContext.SystemPages.Where(x => !x.Deleted).Select(x =>
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

        public WebApiPagingResult<List<PageListModel>> GetAllPages(PagingOptions<SearchPageDto> paging)
        {
            var result = new WebApiPagingResult<List<PageListModel>>();
            try
            {
                var sql = @"SELECT * FROM [ViewPageList]";
                var countSql = @"SELECT COUNT(*) FROM [ViewPageList]";

                if (paging.Filter != null)
                {
                    sql = sql + this.GetAllPagesQuerySql(paging.Filter);
                    countSql = countSql + this.GetAllPagesQuerySql(paging.Filter);
                }

                sql = sql + this.GetPagingSql<SearchPageDto>(paging, "MenuOrder");

                var views = _dapperContext.Conn.Query<ViewPageList>(sql).ToList();
                if (!views.Any())
                {
                    return result;
                }

                result.RowsCount = _dapperContext.Conn.QueryFirstOrDefault<int>(countSql);

                views = views.OrderBy(x => x.MenuOrder).ThenBy(x=>x.Order).ToList();
                var data = _mapper.Map<List<ViewPageList>, List<PageListModel>>(views);
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        public string GetAllPagesQuerySql(SearchPageDto dto)
        {
            try
            {
                var query = "";

                if (!string.IsNullOrEmpty(dto.Name))
                {
                    query = "WHERE [Name] LIKE '%" + dto.Name + "%'";
                }

                if (!string.IsNullOrEmpty(dto.Menu))
                {
                    query = "WHERE [MenuName] LIKE '%" + dto.Menu + "%'";
                }

                if (!string.IsNullOrEmpty(dto.Name) && !string.IsNullOrEmpty(dto.Menu))
                {
                    query = "WHERE [Name] LIKE '%" + dto.Name + "%' AND [MenuName] LIKE '%" + dto.Menu + "%'";
                }

                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetPagingSql<T>(PagingOptions<T> paging,string order)
        {
            try
            {
                var pageIndex = paging.PageIndex;
                var pageSize = paging.PageSize;

                var pageSql = "ORDER BY [" + order + "] OFFSET " + pageSize * pageIndex + " rows FETCH next " +
                              pageSize + " rows only";

                return pageSql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

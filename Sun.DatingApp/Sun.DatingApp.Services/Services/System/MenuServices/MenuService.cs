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
using Sun.DatingApp.Utility.SqlUtility;
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

        public WebApiPagingResult<List<MenuListModel>> GetMenus(PagingOptions paging)
        {
            var result = new WebApiPagingResult<List<MenuListModel>>();
            try
            {
                var query = " WHERE [Deleted] = N'0'";
                var sql = ListSqlUtility.GetListSql("SystemMenu", query, paging, "Order");
                var countSql = ListSqlUtility.GetListCountSql("SystemMenu", query);

                var entitis = _dapperContext.Conn.Query<SystemMenu>(sql).ToList();
                if (!entitis.Any())
                {
                    return result;
                }
                result.RowsCount = _dapperContext.Conn.QueryFirstOrDefault<int>(countSql);

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
                var entity = _mapper.Map<MenuEditDto, SystemMenu>(dto);
                entity.CreatedById = accountId;

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
                entity.Order = dto.Order;

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
                var existPage = await _dataContext.SystemPages.AnyAsync(x=>x.MenuId == id && !x.Deleted);
                if (existPage)
                {
                    result.AddError("当前菜单下存在页面，不能删除！");
                    return result;
                }

                var entity = await _dataContext.SystemMenus.FirstOrDefaultAsync(x => x.Id == id);
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

        public WebApiPagingResult<List<PageListModel>> GetPages(PagingOptions<SearchMenuPageDto> paging)
        {
            var result = new WebApiPagingResult<List<PageListModel>>();
            try
            {
                var query = this.GetPagesQuerySql(paging.Filter);
                var sql = ListSqlUtility.GetListSql("SystemPage", query, paging, "Order");
                var countSql = ListSqlUtility.GetListCountSql("SystemPage", query);

                var entitis = _dapperContext.Conn.Query<SystemPage>(sql).ToList();
                if (!entitis.Any())
                {
                    return result;
                }

                result.RowsCount = _dapperContext.Conn.QueryFirstOrDefault<int>(countSql);

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
                var entity = _mapper.Map<PageEditDto, SystemPage>(dto);
                entity.CreatedById = accountId;

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
                entity.Order = dto.Order;

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

                //删除角色关联的该页面权限
                await _dataContext.SystemRolePermissions.Where(x => x.PageId == id).ForEachAsync(x =>
                {
                    x.Deleted = true;
                    x.DeletedAt = DateTime.Now;
                    x.DeletedById = accountId;
                });

                //删除页面下权限
                await _dataContext.SystemPermissions.Where(x => x.PageId == id).ForEachAsync(x =>
                {
                    x.Deleted = true;
                    x.DeletedAt = DateTime.Now;
                    x.DeletedById = accountId;
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
                var query = "";
                if (paging.Filter != null)
                {
                    query = query + this.GetAllPagesQuerySql(paging.Filter);
                }

                var sql = ListSqlUtility.GetListSql("ViewPageList", query, paging, "MenuOrder");
                var countSql = ListSqlUtility.GetListCountSql("ViewPageList", query);

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




        private string GetAllPagesQuerySql(SearchPageDto dto)
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

        private string GetPagesQuerySql(SearchMenuPageDto dto)
        {
            try
            {
                var query = "";

                if (!string.IsNullOrEmpty(dto.Name))
                {
                    query = " WHERE [MenuId] = '" + dto.Id +
                            "' AND [Deleted] = N'0' AND [Name] LIKE '%" + dto.Name + "%'";
                }
                else
                {
                    query = " WHERE [MenuId] = '" + dto.Id +
                            "' AND [Deleted] = N'0'";
                }

                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

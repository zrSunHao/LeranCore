using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Common.Dto;
using Sun.DatingApp.Model.Menus.Model;
using Sun.DatingApp.Model.System.Menus.Dto;
using Sun.DatingApp.Model.System.Menus.Model;
using Sun.DatingApp.Services.Services.Common.BaseServices;
using Sun.DatingApp.Utility.CacheUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sun.DatingApp.Model.Common.Model;

namespace Sun.DatingApp.Services.Services.System.MenuServices
{
    public class MenuService : BaseService, IMenuService
    {
        public MenuService(DataContext dataContext, IMapper mapper, ICacheHandler catchHandler) : base(dataContext, mapper, catchHandler)
        {
        }

        public async Task<WebApiResult<List<MenuListModel>>> GetMenus()
        {
            var result = new WebApiResult<List<MenuListModel>>();
            try
            {
                var data = await (from m in _dataContext.Menus
                    where !m.Deleted
                    select new MenuListModel
                    {
                        Id = m.Id,
                        Name = m.Name,
                        TagColor = m.TagColor,
                        Intro = m.Intro,
                        Icon = m.Icon,
                        Active = m.Active
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

        public async Task<WebApiResult> CreateMenu(MenuEditDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var entity = new Menu
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

                _dataContext.Menus.Add(entity);
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

                var entity = await _dataContext.Menus.FirstOrDefaultAsync(x => x.Id == dto.Id.Value);
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
                var entity = await _dataContext.Menus.FirstOrDefaultAsync(x => x.Id == dto.Id);
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
                var entity = await _dataContext.Menus.FirstOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                {
                    result.AddError("数据为空");
                    return result;
                }

                entity.Deleted = true;
                entity.DeletedAt = DateTime.Now;
                entity.DeletedById = accountId;

                await _dataContext.Pages.Where(x => x.MenuId == entity.Id).ForEachAsync(c =>
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


        public async Task<WebApiResult<List<PageListModel>>> GetPages(Guid id)
        {
            var result = new WebApiResult<List<PageListModel>>();
            try
            {
                var data = await (from p in _dataContext.Pages
                    where !p.Deleted && p.MenuId == id
                    select new PageListModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Url = p.Url,
                        TagColor = p.TagColor,
                        Intro = p.Intro,
                        Icon = p.Icon,
                        Active = p.Active,
                        MenuId = p.MenuId,
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

        public async Task<WebApiResult> CreatePage(PageEditDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var entity = new Page
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

                _dataContext.Pages.Add(entity);
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

                var entity = await _dataContext.Pages.FirstOrDefaultAsync(x => x.Id == dto.Id.Value);
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
                var entity = await _dataContext.Pages.FirstOrDefaultAsync(x => x.Id == dto.Id);
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
                var entity = await _dataContext.Pages.FirstOrDefaultAsync(x => x.Id == id);
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
                var data = await _dataContext.Pages.Where(x => !x.Deleted).Select(x =>
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

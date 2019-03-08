using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Menus.Dto;
using Sun.DatingApp.Model.Menus.Model;
using Sun.DatingApp.Services.Services.BaseServices;
using Sun.DatingApp.Utility.CacheUtility;

namespace Sun.DatingApp.Services.Services.MenuServices
{
    public class MenuService : BaseService, IMenuService
    {
        public MenuService(DataContext dataContext, IMapper mapper, ICacheService catchService) : base(dataContext, mapper, catchService)
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

        public async Task<WebApiResult> AddMenu(MenuEditDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {

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
                    join m in _dataContext.Permissions on p.ModuleId equals m.Id into tm
                    from pm in tm.DefaultIfEmpty()
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
                        ModuleId = p.ModuleId,
                        ModuleName = pm.Name
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

        public async Task<WebApiResult> AddPage(PageEditDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {

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

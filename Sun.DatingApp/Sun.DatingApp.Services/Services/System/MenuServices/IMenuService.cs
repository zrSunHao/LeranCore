using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Common.Dto;
using Sun.DatingApp.Model.Menus.Model;
using Sun.DatingApp.Model.System.Menus.Dto;
using Sun.DatingApp.Model.System.Menus.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sun.DatingApp.Model.Common.Model;

namespace Sun.DatingApp.Services.Services.System.MenuServices
{
    public interface IMenuService
    {
        Task<WebApiResult<List<MenuListModel>>> GetMenus();

        Task<WebApiResult> CreateMenu(MenuEditDto dto, Guid accountId);

        Task<WebApiResult> EditMenu(MenuEditDto dto, Guid accountId);

        Task<WebApiResult> ActiveMenu(ActiveDto dto, Guid accountId);

        Task<WebApiResult> DeleteMenu(Guid id, Guid accountId);


        Task<WebApiResult<List<PageListModel>>> GetPages(Guid id);

        Task<WebApiResult> CreatePage(PageEditDto dto, Guid accountId);

        Task<WebApiResult> EditPage(PageEditDto dto, Guid accountId);

        Task<WebApiResult> ActivePage(ActiveDto dto, Guid accountId);

        Task<WebApiResult> DeletePage(Guid id, Guid accountId);

        Task<WebApiResult<List<ItemModel>>> GetPageItems();

        Task<WebApiResult<List<PageListModel>>> GetAllPages(string name);

    }
}

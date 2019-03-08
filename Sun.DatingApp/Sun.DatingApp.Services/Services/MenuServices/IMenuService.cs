﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Menus.Dto;
using Sun.DatingApp.Model.Menus.Model;

namespace Sun.DatingApp.Services.Services.MenuServices
{
    public interface IMenuService
    {
        Task<WebApiResult<List<MenuListModel>>> GetMenus();

        Task<WebApiResult> AddMenu(MenuEditDto dto, Guid accountId);

        Task<WebApiResult> EditMenu(MenuEditDto dto, Guid accountId);

        Task<WebApiResult> ActiveMenu(ActiveDto dto, Guid accountId);

        Task<WebApiResult<List<PageListModel>>> GetPages(Guid id);

        Task<WebApiResult> AddPage(PageEditDto dto, Guid accountId);

        Task<WebApiResult> EditPage(PageEditDto dto, Guid accountId);

        Task<WebApiResult> ActivePage(ActiveDto dto, Guid accountId);

    }
}
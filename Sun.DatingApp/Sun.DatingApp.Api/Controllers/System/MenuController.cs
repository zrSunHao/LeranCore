using Microsoft.AspNetCore.Mvc;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Common.Dto;
using Sun.DatingApp.Model.Common.Model;
using Sun.DatingApp.Model.System.Menus.Dto;
using Sun.DatingApp.Model.System.Menus.Model;
using Sun.DatingApp.Services.Services.System.MenuServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sun.DatingApp.Api.Extensions.Authorization;

namespace Sun.DatingApp.Api.Controllers.System
{
    public class MenuController : BaseController
    {
        private readonly IMenuService _service;

        public MenuController(IMenuService service)
        {
            _service = service;
        }

        /// <summary>
        /// 获取菜单列表数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetMenus")]
        [PermissionFilter(Permissions.GetMenus)]
        public WebApiResult<List<MenuListModel>> GetMenus()
        {
            return _service.GetMenus();
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpPost("CreateMenu")]
        [PermissionFilter(Permissions.CreateMenu)]
        public async Task<WebApiResult> CreateMenu(MenuEditDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.CreateMenu(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 编辑菜单
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpPost("EditMenu")]
        public async Task<WebApiResult> EditMenu(MenuEditDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.EditMenu(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 启用菜单
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpPost("ActiveMenu")]
        public async Task<WebApiResult> ActiveMenu(ActiveDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.ActiveMenu(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpGet("DeleteMenu")]
        [PermissionFilter(Permissions.DeleteMenu)]
        public async Task<WebApiResult> DeleteMenu(Guid id, Guid accountId)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.DeleteMenu(id, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }


        /// <summary>
        /// 获取页面列表数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetPages")]
        public WebApiResult<List<PageListModel>> GetPages(Guid id)
        {
            return _service.GetPages(id);
        }

        /// <summary>
        /// 添加页面
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpPost("CreatePage")]
        public async Task<WebApiResult> CreatePage(PageEditDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.CreatePage(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 编辑页面
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpPost("EditPage")]
        public async Task<WebApiResult> EditPage(PageEditDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.EditPage(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 启用页面
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpPost("ActivePage")]
        public async Task<WebApiResult> ActivePage(ActiveDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.ActivePage(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 删除页面
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpGet("DeletePage")]
        [PermissionFilter(Permissions.DeletePage)]
        public async Task<WebApiResult> DeletePage(Guid id, Guid accountId)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.DeletePage(id, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }



        /// <summary>
        /// 获取页面选择列表信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPageItems")]
        public async Task<WebApiResult<List<ItemModel>>> GetPageItems()
        {
            return await _service.GetPageItems();
        }

        /// <summary>
        /// 权限列表页获取全部的页面数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllPages")]
        [PermissionFilter(Permissions.GetAllPages)]
        public WebApiResult<List<PageListModel>> GetAllPages(PagingOptions<SearchPageDto> paging)
        {
            return _service.GetAllPages(paging);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Common.Dto;
using Sun.DatingApp.Model.Menus.Model;
using Sun.DatingApp.Model.System.Menus.Dto;
using Sun.DatingApp.Services.Services.System.MenuServices;

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
        [HttpGet("getmenus")]
        public async Task<WebApiResult<List<MenuListModel>>> GetMenus()
        {
            return await _service.GetMenus();
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpPost("addmenu")]
        public async Task<WebApiResult> AddMenu(MenuEditDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.AddMenu(dto, CurrentUserId.Value);
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
        [HttpPost("editmenu")]
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
        [HttpPost("activemenu")]
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
        [HttpGet("deletemenu")]
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
        [HttpGet("getpages")]
        public async Task<WebApiResult<List<PageListModel>>> GetPages(Guid id)
        {
            return await _service.GetPages(id);
        }

        /// <summary>
        /// 添加页面
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpPost("addpage")]
        public async Task<WebApiResult> AddPage(PageEditDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.AddPage(dto, CurrentUserId.Value);
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
        [HttpPost("editpage")]
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
        [HttpPost("activepage")]
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
        [HttpGet("deletepage")]
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
    }
}
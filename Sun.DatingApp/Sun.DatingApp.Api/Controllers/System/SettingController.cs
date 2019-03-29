using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.System.Setting.Dto;
using Sun.DatingApp.Model.System.Setting.Model;
using Sun.DatingApp.Services.Services.System.SettingServices;

namespace Sun.DatingApp.Api.Controllers.System
{
    public class SettingController : BaseController
    {
        private readonly ISettingService _service;

        public SettingController(ISettingService service)
        {
            _service = service;
        }

        /// <summary>
        /// 获取系统设置列表
        /// </summary>
        /// <param name="paging"></param>
        /// <returns></returns>
        [HttpPost("GetSettings")]
        public WebApiPagingResult<List<SettingListModel>> GetSettings(PagingOptions<SettingSearchDto> paging)
        {
            return _service.GetSettings(paging);
        }

        /// <summary>
        /// 创建系统设置
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("CreateSetting")]
        public async Task<WebApiResult> CreateSetting(EditSettingDto dto)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.CreateSetting(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }

        /// <summary>
        /// 修改系统设置
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("EditSetting")]
        public async Task<WebApiResult> EditSetting(EditSettingDto dto)
        {
            var result = new WebApiResult();
            if (CurrentUserId.HasValue)
            {
                result = await _service.EditSetting(dto, CurrentUserId.Value);
            }
            else
            {
                result.AddError("当前用户信息获取失败");
            }
            return result;
        }
    }
}
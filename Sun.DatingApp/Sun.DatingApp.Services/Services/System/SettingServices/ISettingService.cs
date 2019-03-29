using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.System.Setting.Dto;
using Sun.DatingApp.Model.System.Setting.Model;

namespace Sun.DatingApp.Services.Services.System.SettingServices
{
    public interface ISettingService
    {
        WebApiPagingResult<List<SettingListModel>> GetSettings(PagingOptions<SettingSearchDto> paging);

        Task<WebApiResult> CreateSetting(EditSettingDto dto, Guid accountId);

        Task<WebApiResult> EditSetting(EditSettingDto dto, Guid accountId);
    }
}

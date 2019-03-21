using System;
using System.Threading.Tasks;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.System.Users.Dto;
using Sun.DatingApp.Model.System.Users.Model;
using Sun.DatingApp.Services.Services.Common.BaseServices;

namespace Sun.DatingApp.Services.Services.System.UserServices
{
    public interface IUserService : IBaseService
    {
        Task<WebApiResult<UserInfoModel>> GetUserInfo(Guid accountId);

        Task<WebApiResult> EditUserInfo(UserInfoDto dto, Guid accountId);
    }
}

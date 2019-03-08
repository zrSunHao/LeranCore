using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.System.Auth.Accounts.Dto;
using Sun.DatingApp.Model.System.Auth.Accounts.Model;
using Sun.DatingApp.Model.System.Auth.Login.Model;
using Sun.DatingApp.Model.System.Auth.Register.Dto;

namespace Sun.DatingApp.Services.Services.System.AuthServices
{
    public interface IAuthService
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<WebApiResult> Register(RegisterDto dto);

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<WebApiResult<AccessDataModel>> Login(string account, string password);

        /// <summary>
        /// 获取新的RefreshToken
        /// </summary>
        /// <param name="oldRefreshToken"></param>
        /// <returns></returns>
        Task<WebApiResult<AccessDataModel>> Refresh(Guid oldRefreshToken);

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<WebApiResult> Logout(Guid id);

        /// <summary>
        /// 用户管理列表
        /// </summary>
        /// <param name="opt"></param>
        /// <returns></returns>
        Task<WebApiPagingResult<List<AccountListModel>>> Accounts(PagingOptions<AccountListQueryDto> opt);

        /// <summary>
        /// 禁用或启用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<WebApiResult> Forbidden(ForbiddenDto dto);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<WebApiResult> BatchDelete(List<Guid> ids);
    }
}

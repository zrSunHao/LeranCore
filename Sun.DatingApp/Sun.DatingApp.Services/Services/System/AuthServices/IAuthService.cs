using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Common.Dto;
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
        /// 账号管理列表
        /// </summary>
        /// <param name="opt"></param>
        /// <returns></returns>
        Task<WebApiPagingResult<List<AccountListModel>>> Accounts(PagingOptions<AccountListQueryDto> opt);

        /// <summary>
        /// 编辑账号
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<WebApiResult> EditAccount(EditAccountDto dto, Guid accountId);

        /// <summary>
        /// 批量编辑
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<WebApiResult> BatchEditAccount(BatchEditAccountDto dto, Guid accountId);

        /// <summary>
        /// 启用或禁用账号
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<WebApiResult> ActiveAccount(ActiveDto dto, Guid accountId);

        /// <summary>
        /// 锁定账号
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<WebApiResult> LockoutAccount(LockoutAccountDto dto, Guid accountId);

        /// <summary>
        /// 删除账号
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<WebApiResult> DeleteAccount(Guid id, Guid accountId);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<WebApiResult> BatchDeleteAccount(List<Guid> ids, Guid accountId);
    }
}

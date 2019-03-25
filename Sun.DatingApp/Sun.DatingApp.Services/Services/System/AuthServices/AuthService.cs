using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.Common.Dto;
using Sun.DatingApp.Model.System.Auth.Accounts.Dto;
using Sun.DatingApp.Model.System.Auth.Accounts.Model;
using Sun.DatingApp.Model.System.Auth.Info;
using Sun.DatingApp.Model.System.Auth.Login.Model;
using Sun.DatingApp.Model.System.Auth.Register.Dto;
using Sun.DatingApp.Services.Services.Common.BaseServices;
using Sun.DatingApp.Utility.CacheUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Sun.DatingApp.Data.View.System;
using Sun.DatingApp.Utility.Password;

namespace Sun.DatingApp.Services.Services.System.AuthServices
{
    public class AuthService : BaseService ,IAuthService
    {
        public AuthService(DataContext dataContext, IMapper mapper, ICacheHandler catchHandler) : base(dataContext, mapper, catchHandler)
        {
        }

        public async Task<WebApiResult> Register(RegisterDto dto)
        {
            var result = new WebApiResult();
            try
            {
                var emailExist = await _dataContext.SystemAccounts.AsNoTracking().AnyAsync(x => x.Email == dto.Email && !x.Deleted);
                if (emailExist)
                {
                    result.AddError(dto.Email + "该邮箱已被注册");
                    return result;
                }

                var mobileExist = await _dataContext.SystemAccounts.AsNoTracking().AnyAsync(x => x.Email == dto.Email && !x.Deleted);
                if (mobileExist)
                {
                    result.AddError(dto.Email + "该手机号码已被注册");
                    return result;
                }

                var role = await _dataContext.SystemRoles.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Name == "用户" && !x.Deleted);
                if (role == null)
                {
                    result.AddError("当前系统未设置默认用户角色，请联系管理员");
                    return result;
                }

                var account = _mapper.Map<RegisterDto, SystemAccount>(dto);

                byte[] passwordHash, passwordSalt;
                PasswordUtility.CreatePasswordHash(dto.Password, out passwordHash, out passwordSalt);

                account.PasswordSalt = passwordSalt;
                account.PasswordHash = passwordHash;
                account.RoleId = role.Id;

                await _dataContext.SystemAccounts.AddAsync(account);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                result.AddError("出现异常，注册失败，请联系管理员");
            }

            return result;
        }

        public async Task<WebApiResult<AccountInfo>> Login(string email, string password)
        {
            var result = new WebApiResult<AccountInfo>();
            try
            {
                var exist = await _dataContext.SystemAccounts.AsNoTracking().AnyAsync(x => x.Email == email);
                if (!exist)
                {
                    result.AddError("账号或密码错误");
                    return result;
                }

                var account = await _dataContext.SystemAccounts.FirstOrDefaultAsync(x => x.Email == email);

                bool verify = PasswordUtility.VerifyPasswordHash(password, account.PasswordHash, account.PasswordSalt);
                if (!verify)
                {
                    result.AddError("账号或密码错误");
                }
                if (account.LockoutEndAt.HasValue && account.LockoutEndAt > DateTime.Now)
                {
                    var time = account.LockoutEndAt.Value;
                    var err = "账号已被锁定至" + time.Year + "年" + time.Month + "月" + time.Day + "日";
                    result.AddError(err);
                }
                if (!result.Success)
                {
                    return result;
                }

                var refreshToken = Guid.NewGuid();
                account.RefreshToken = refreshToken;
                await _dataContext.SaveChangesAsync();

                var role = await _dataContext.SystemRoles.FirstOrDefaultAsync(x => x.Id == account.RoleId);
                if (role == null)
                {
                    result.AddError("该账号没有角色，请联系管理员");
                    return result;
                }

                var avatar = await this.GetAccountAvatar(account.Id);

                var info = new AccountInfo()
                {
                    Id = account.Id,
                    Email = account.Email,
                    Name = account.Nickname,
                    RoleId = role.Id,
                    Avatar = avatar,
                    RoleName = role.Name,
                    RefreshToken = account.RefreshToken
                };

                result.Data = info;
                return result;
            }
            catch (Exception ex)
            {
                result.AddError("出现异常，请联系管理员");
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
                return result;
            }
        }

        public async Task<WebApiResult<AccessDataModel>> Refresh(Guid oldRefreshToken)
        {
            var result = new WebApiResult<AccessDataModel>();

            try
            {
                var account = await _dataContext.SystemAccounts.FirstOrDefaultAsync(x => x.RefreshToken == oldRefreshToken);

                if (account == null)
                {
                    result.AddError("根据RefreshToken未获取到对应的用户");
                    return result;
                }
                if (account.LockoutEndAt.HasValue && account.LockoutEndAt > DateTime.Now)
                {
                    var time = account.LockoutEndAt.Value;
                    var err = "账号已被锁定至" + time.Year + "年" + time.Month + "月" + time.Day + "日";
                    result.AddError(err);
                }

                account.RefreshToken = Guid.NewGuid();
                await _dataContext.SaveChangesAsync();

                result.Data = _mapper.Map<SystemAccount, AccessDataModel>(account);
                return result;
            }
            catch (Exception e)
            {
                result.AddError("获取新的Token失败");
            }

            return result;
        }

        public async Task<WebApiResult> Logout(Guid id)
        {
            var result = new WebApiResult();
            try
            {
                var account = await _dataContext.SystemAccounts.FirstOrDefaultAsync(x => x.Id == id);
                if (account == null)
                {
                    result.AddError("未找到对应的用户");
                }
                else
                {
                    account.RefreshToken = null;
                    await _dataContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                result.AddError("出现异常");
            }
            return result;
        }


        #region 账号管理
        //TODO 分页
        public WebApiPagingResult<List<AccountListModel>> Accounts(PagingOptions<AccountListQueryDto> opt)
        {
            var result = new WebApiPagingResult<List<AccountListModel>>();
            try
            {
                if (opt == null)
                {
                    result.AddError("传递的查询条件为空");
                    return result;
                }

                var sql = @"SELECT * FROM [ViewAccountList]";
                var views = _dapperContext.Conn.Query<ViewAccountList>(sql).ToList();
                if (!views.Any())
                {
                    return result;
                }

                views = views.OrderBy(x => x.RoleRank).ThenByDescending(x => x.LatestLoginAt).ToList();
                var data = _mapper.Map<List<ViewAccountList>, List<AccountListModel>>(views);
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.AddError(ex.ToString());
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        public async Task<WebApiResult> CreateAccount(EditAccountDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var emailExist = await _dataContext.SystemAccounts.AnyAsync(x => x.Email == dto.Email && !x.Deleted);
                if (emailExist)
                {
                    result.AddError("邮箱已存在");
                    return result;
                }

                byte[] passwordHash, passwordSalt;
                PasswordUtility.CreatePasswordHash("pandora", out passwordHash, out passwordSalt);

                var entity = new SystemAccount
                {
                    Id = Guid.NewGuid(),
                    Email = dto.Email,
                    Nickname = dto.UserName,
                    RoleId = dto.RoleId,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Active = true,
                    AccessFailedCount = 0,
                    CreatedAt = DateTime.Now,
                    CreatedById = accountId,
                    Deleted = false
                };

                _dataContext.SystemAccounts.Add(entity);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        public async Task<WebApiResult> EditAccount(EditAccountDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var entity = await _dataContext.SystemAccounts.FirstOrDefaultAsync(x => x.Id == dto.Id);
                if (entity == null)
                {
                    result.AddError("数据为空");
                    return result;
                }

                var emailExist = await _dataContext.SystemAccounts.AnyAsync(x => x.Id != dto.Id && x.Email == dto.Email && !x.Deleted);
                if (emailExist)
                {
                    result.AddError("邮箱已存在");
                    return result;
                }

                entity.Email = dto.Email;
                entity.Nickname = dto.UserName;
                entity.RoleId = dto.RoleId;

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        public async Task<WebApiResult> BatchEditAccount(BatchEditAccountDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                if (dto.Ids == null || !dto.Ids.Any())
                {
                    result.AddError("请选择要操作的账号");
                    return result;
                }

                if (dto.Active.HasValue && !dto.LockoutEndAt.HasValue)
                {
                    await _dataContext.SystemAccounts.Where(x => dto.Ids.Contains(x.Id))
                        .ForEachAsync(x =>
                        {
                            x.Active = dto.Active.Value;
                            x.UpdatedAt = DateTime.Now;
                            x.UpdatedById = accountId;
                        });
                }

                if (!dto.Active.HasValue && dto.LockoutEndAt.HasValue)
                {
                    await _dataContext.SystemAccounts.Where(x => dto.Ids.Contains(x.Id))
                        .ForEachAsync(x =>
                        {
                            x.LockoutEndAt = dto.LockoutEndAt.Value;
                            x.UpdatedAt = DateTime.Now;
                            x.UpdatedById = accountId;
                        });
                }

                if (dto.Active.HasValue && dto.LockoutEndAt.HasValue)
                {
                    await _dataContext.SystemAccounts.Where(x => dto.Ids.Contains(x.Id))
                        .ForEachAsync(x =>
                        {
                            x.Active = dto.Active.Value;
                            x.LockoutEndAt = dto.LockoutEndAt.Value;
                            x.UpdatedAt = DateTime.Now;
                            x.UpdatedById = accountId;
                        });
                }

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex )
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        public async Task<WebApiResult> ActiveAccount(ActiveDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var entity = await _dataContext.SystemAccounts.FirstOrDefaultAsync(x => x.Id == dto.Id);
                if (entity == null)
                {
                    result.AddError("数据为空");
                    return result;
                }

                if (dto.Active == entity.Active)
                {
                    var errMsg = "";
                    if (entity.Active) errMsg = "账号早已开启"; else errMsg = "账号早已关闭";
                    result.AddError(errMsg);
                    return result;
                }

                entity.Active = dto.Active;
                entity.UpdatedAt = DateTime.Now;
                entity.UpdatedById = accountId;

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        public async Task<WebApiResult> LockoutAccount(LockoutAccountDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var entity = await _dataContext.SystemAccounts.FirstOrDefaultAsync(x => x.Id == dto.Id);
                if (entity == null)
                {
                    result.AddError("数据为空");
                    return result;
                }

                entity.LockoutEndAt = dto.LockoutEndAt;
                entity.UpdatedAt = DateTime.Now;
                entity.UpdatedById = accountId;

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        public async Task<WebApiResult> DeleteAccount(Guid id, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var entity = await _dataContext.SystemAccounts.FirstOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                {
                    result.AddError("数据为空");
                    return result;
                }

                entity.Deleted = true;
                entity.DeletedAt = DateTime.Now;
                entity.DeletedById = accountId;

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result.AddError(ex.Message);
            }
            return result;
        }

        public async Task<WebApiResult> BatchDeleteAccount(BatchDeleteAccountDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                if (dto == null || !dto.Ids.Any())
                {
                    result.AddError("请选择要删除的账号！");
                    return result;
                }
                await _dataContext.SystemAccounts.Where(x => dto.Ids.Contains(x.Id)).ForEachAsync(y =>
                {
                    y.Deleted = true;
                    y.DeletedAt = DateTime.Now;
                    y.DeletedById = CurrentUserId;
                });
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError("出现异常，删除失败");
            }
            return result;
        }

        public async Task<WebApiResult> BindAvatar(FileDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var entity = new SystemAccountAvatar
                {
                    Id = Guid.NewGuid(),
                    AccountId = accountId,
                    FileName = dto.FileName,
                    Url = dto.Url,
                    FileType = dto.FileType,
                    FileLength = dto.FileLength,
                    CreatedAt = DateTime.Now,
                    CreatedById = accountId,
                    Deleted = false
                };

                _dataContext.Add(entity);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        public async Task<WebApiResult<string>> GetUserAvatar(Guid accountId)
        {
            var result = new WebApiResult<string>();
            try
            {
                result.Data = await this.GetAccountAvatar(accountId);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        #endregion


        #region 账号登录信息
        //TODO 分页
        public WebApiResult<AccountInfo> GetAccountInfo(Guid id)
        {
            var result = new WebApiResult<AccountInfo>();
            try
            {
                var sql = @"SELECT TOP 1 * FROM [ViewAccountList] WHERE  [Id] = @Id";
                var view = _dapperContext.Conn.QueryFirst<ViewAccountList>(sql, new {Id = id});

                var data = _mapper.Map<ViewAccountList, AccountInfo>(view);
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.AddError("获取账号基本信息时出现异常");
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        public async Task<WebApiResult<AccountMenuInfo>> GetAccountMenu(Guid id)
        {
            var result = new WebApiResult<AccountMenuInfo>();
            try
            {
                var account = await _dataContext.SystemAccounts.FirstOrDefaultAsync(x => x.Id == id);
                if (account == null)
                {
                    result.AddError("未找到对应的用户");
                    return result;
                }

                var permsItems = await _dataContext.SystemRolePermissions.Where(x=>x.RoleId == account.RoleId && !x.Deleted).ToListAsync();
                var pageIds = permsItems.Select(x => x.PageId).ToList();

                if (pageIds.Any())
                {
                    var info = await this.GetAccountPermission(pageIds);
                    result.Data = info;
                }
            }
            catch (Exception ex)
            {
                result.AddError("获取账号权限时出现异常");
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        public WebApiResult<string[]> GetAccountPermission(Guid roleId)
        {
            var result = new WebApiResult<string[]>();
            try
            {
                var sql = @"SELECT TOP 1000 * FROM [ViewAuthorizationRolePermission] WHERE [RoleId] = @Id";
                var perms = _dapperContext.Conn.Query<ViewAuthorizationRolePermission>(sql, new { Id = roleId }).ToList();

                var permsStr = perms.Where(x => x.PermissionActive).Select(x => x.PermissionCode).ToArray();
                result.Data = permsStr;
            }
            catch (Exception ex)
            {
                result.AddError("获取账号菜单数据时出现异常");
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        #endregion


        #region 私有方法

        private async Task<AccountMenuInfo> GetAccountPermission(List<Guid> pageIds)
        {
            try
            {
                var menuInfo = new AccountMenuInfo
                {
                    Text = "主导航",
                    Group = true,
                    HideInBreadcrumb = true,
                };

                var pages = await _dataContext.SystemPages.Where(x => pageIds.Contains(x.Id) && !x.Deleted).ToListAsync();
                var menuIds = pages.Select(x => x.MenuId).ToList();
                var menus = await _dataContext.SystemMenus.Where(x => menuIds.Contains(x.Id)).ToListAsync();

                if (menus.Any())
                {
                    var accountMenus = new List<AccountMenu>();

                    foreach (var menu in menus)
                    {
                        var accountMenu = new AccountMenu
                        {
                            Key = menu.Id,
                            Text = menu.Name,
                            Icon = "anticon anticon-" + menu.Icon,
                            ShortcutRoot = true,
                        };

                        accountMenu.Children = pages.Where(x => x.MenuId == menu.Id).Select(x => new AccountPage
                        {
                            Key = x.Id,
                            Text = x.Name,
                            Link = x.Url
                        }).ToList();

                        accountMenus.Add(accountMenu);
                    }

                    menuInfo.Children = accountMenus;
                }

                return menuInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<string> GetAccountAvatar(Guid accountId)
        {
            try
            {
                var url = "";
                var avatars = await _dataContext.SystemAccountAvatars.Where(x => x.AccountId == accountId).ToListAsync();
                if (avatars.Any())
                {
                    var createAt = DateTime.MinValue;
                    foreach (var avatar in avatars)
                    {
                        if (createAt < avatar.CreatedAt)
                        {
                            createAt = avatar.CreatedAt;
                            url = avatar.Url;
                        }
                    }
                }

                return url;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}

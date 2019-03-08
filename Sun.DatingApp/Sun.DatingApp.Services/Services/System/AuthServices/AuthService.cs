using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.System.Auth.Accounts.Dto;
using Sun.DatingApp.Model.System.Auth.Accounts.Model;
using Sun.DatingApp.Model.System.Auth.Login.Model;
using Sun.DatingApp.Model.System.Auth.Register.Dto;
using Sun.DatingApp.Services.Services.Common.BaseServices;
using Sun.DatingApp.Utility.CacheUtility;

namespace Sun.DatingApp.Services.Services.System.AuthServices
{
    public class AuthService : BaseService ,IAuthService
    {
        public AuthService(DataContext dataContext, IMapper mapper, ICacheService catchService) : base(dataContext, mapper, catchService)
        {
        }

        public async Task<WebApiResult> Register(RegisterDto dto)
        {
            var result = new WebApiResult();
            try
            {
                var exist = await _dataContext.Accounts.AsNoTracking().AnyAsync(x => x.Email == dto.Email && !x.Deleted);
                if (exist)
                {
                    result.AddError(dto.Email + "邮箱已被注册");
                    return result;
                }

                var role = await _dataContext.Roles.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Code == "User" && !x.Deleted);
                if (role == null)
                {
                    result.AddError("当前系统未设置默认用户角色，请联系管理员");
                    return result;
                }

                var account = _mapper.Map<RegisterDto, Account>(dto);

                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(dto.Password, out passwordHash, out passwordSalt);

                account.PasswordSalt = passwordSalt;
                account.PasswordHash = passwordHash;
                account.RoleCode = role.Code;
                account.RoleId = role.Id;

                await _dataContext.Accounts.AddAsync(account);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                result.AddError("出现异常，注册失败，请联系管理员");
            }

            return result;
        }

        public async Task<WebApiResult<AccessDataModel>> Login(string email, string password)
        {
            var result = new WebApiResult<AccessDataModel>();
            try
            {
                var exist = await _dataContext.Accounts.AsNoTracking().AnyAsync(x => x.Email == email);
                if (!exist)
                {
                    result.AddError("账号或密码错误");
                    return result;
                }

                var account = await _dataContext.Accounts.FirstOrDefaultAsync(x => x.Email == email);

                bool verify = VerifyPasswordHash(password, account.PasswordHash, account.PasswordSalt);
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

                var permissions = await (from rp in _dataContext.RolePermissions
                    join p in _dataContext.Permissions on rp.RoleId equals p.Id into tp
                    from prp in tp.DefaultIfEmpty()
                    where !rp.Deleted && rp.RoleId == account.RoleId
                    select prp.Code).ToListAsync();

                var data = _mapper.Map<Account, AccessDataModel>(account);
                var role = _dataContext.Roles.FirstOrDefault(x => x.Id == account.RoleId);
                if (role != null)
                {
                    data.Role = role.Code;
                }
                data.Permissions = permissions;
                _catchService.Add(data.Id.ToString(), data);
                result.Data = data;
                return result;
            }
            catch (Exception e)
            {
                result.AddError("出现异常，请联系管理员");
                return result;
            }
        }

        public async Task<WebApiResult<AccessDataModel>> Refresh(Guid oldRefreshToken)
        {
            var result = new WebApiResult<AccessDataModel>();

            try
            {
                var account = await _dataContext.Accounts.FirstOrDefaultAsync(x => x.RefreshToken == oldRefreshToken);

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

                result.Data = _mapper.Map<Account, AccessDataModel>(account);
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
                var account = await _dataContext.Accounts.FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task<WebApiPagingResult<List<AccountListModel>>> Accounts(PagingOptions<AccountListQueryDto> opt)
        {
            var result = new WebApiPagingResult<List<AccountListModel>>();
            try
            {
                if (opt == null)
                {
                    result.AddError("传递的查询条件为空");
                    return result;
                }

                var query = _dataContext.Accounts.Where(x => !x.Deleted).AsQueryable();

                var filters = opt.Filters;

                query = from u in query
                    where (!string.IsNullOrEmpty(filters.Email) && u.Email.Contains(filters.Email)) ||
                          string.IsNullOrEmpty(filters.Email)
                    where (!string.IsNullOrEmpty(filters.UserName) && u.Email.Contains(filters.UserName)) ||
                          string.IsNullOrEmpty(filters.UserName)
                    where (!string.IsNullOrEmpty(filters.Role) && u.Email.Contains(filters.Role)) ||
                          string.IsNullOrEmpty(filters.Role)
                    where (filters.Active.HasValue && u.Active == filters.Active) || !filters.Active.HasValue
                    where (filters.LatestLoginAtStart.HasValue && u.LatestLoginAt >= filters.LatestLoginAtStart) ||
                          !filters.LatestLoginAtStart.HasValue
                    where (filters.LatestLoginAtEnd.HasValue &&
                           u.LatestLoginAt < (filters.LatestLoginAtEnd.Value.AddDays(1))) ||
                          !filters.LatestLoginAtEnd.HasValue
                    where (filters.CreatedAtStart.HasValue && u.CreatedAt >= filters.CreatedAtStart) ||
                          !filters.CreatedAtStart.HasValue
                    where (filters.CreatedAtEnd.HasValue && u.CreatedAt < (filters.CreatedAtEnd.Value.AddDays(1))) ||
                          !filters.CreatedAtEnd.HasValue
                    select u;

                result.RowsCount = await query.CountAsync();

                switch (opt.SortField)
                {
                    case "Email":
                        if (opt.SortOrder == "asc")
                            query = query.OrderBy(x => x.Email);
                        query = query.OrderByDescending(x => x.Email);
                        break;
                    case "UserName":
                        if (opt.SortOrder == "asc")
                            query = query.OrderBy(x => x.UserName);
                        query = query.OrderByDescending(x => x.UserName);
                        break;
                    case "Role":
                        if (opt.SortOrder == "asc")
                            query = query.OrderBy(x => x.Role);
                        query = query.OrderByDescending(x => x.Role);
                        break;
                    case "Active":
                        if (opt.SortOrder == "asc")
                            query = query.OrderBy(x => x.Active);
                        query = query.OrderByDescending(x => x.Active);
                        break;
                    case "LatestLoginAt":
                        if (opt.SortOrder == "asc")
                            query = query.OrderBy(x => x.LatestLoginAt);
                        query = query.OrderByDescending(x => x.LatestLoginAt);
                        break;
                    case "CreatedAt":
                        if (opt.SortOrder == "asc")
                            query = query.OrderBy(x => x.CreatedAt);
                        query = query.OrderByDescending(x => x.CreatedAt);
                        break;
                    default:
                        query = query.OrderBy(x => x.LatestLoginAt);
                        break;
                }

                var users = await query.Skip(10 * opt.PageIndex).Take(10).ToListAsync();

                if (users.Any())
                    result.Data = _mapper.Map<List<Account>, List<AccountListModel>>(users);
            }
            catch (Exception ex)
            {
                result.AddError(ex.ToString());
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        public async Task<WebApiResult> Forbidden(ForbiddenDto dto)
        {
            var result = new WebApiResult();
            try
            {
                var user = await _dataContext.Accounts.FirstOrDefaultAsync(x => x.Id == dto.Id && !x.Deleted);
                if (user == null)
                {
                    result.AddError("用户不存在");
                    return result;
                }
                if (user.Active == dto.Forbid)
                {
                    if (user.Active)
                        result.AddError("该用户早已激活");
                    else
                        result.AddError("该用户早已禁用");
                    return result;
                }
                user.Active = dto.Forbid;
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError("出现异常");
            }
            return result;
        }

        public async Task<WebApiResult> BatchDelete(List<Guid> ids)
        {
            var result = new WebApiResult();
            try
            {
                if (!ids.Any())
                {
                    result.AddError("请选择要删除的用户！");
                    return result;
                }
                await _dataContext.Accounts.Where(x => ids.Contains(x.Id)).ForEachAsync(y =>
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

        #region 私有方法

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        #endregion


        
    }
}

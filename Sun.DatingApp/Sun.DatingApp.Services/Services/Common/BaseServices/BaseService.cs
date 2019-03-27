using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Utility.CacheUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Sun.DatingApp.Data.View.System;
using Sun.DatingApp.Utility.Dapper;

namespace Sun.DatingApp.Services.Services.Common.BaseServices
{
    public abstract class BaseService: IBaseService
    {
        public readonly DataContext _dataContext;
        public readonly IMapper _mapper;
        public readonly ICacheHandler _catchHandler;
        public IDapperContext _dapperContext;

        public Guid? CurrentUserId = null;

        public BaseService(
            DataContext dataContext,
            IMapper mapper,
            ICacheHandler catchService
            )
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _catchHandler = catchService;
            _dapperContext = new DapperSqlServerContext();
        }

        public void SetCurrentUserId(Guid? id)
        {
            this.CurrentUserId = id;
        }

        /// <summary>
        /// 获取当前登录用户
        /// </summary>
        public virtual SystemAccount CurrentUser
        {
            get
            {
                if (CurrentUserId.HasValue)
                {
                    return _dataContext.SystemAccounts.FirstOrDefault(x => x.Id == CurrentUserId);
                }
                return null;
            }
        }

        public async Task<List<SystemPermission>> GetPerssionEntitys()
        {
            var entitys = new List<SystemPermission>();
            var catchKey = "PerssionEntitys";
            var exist = this._catchHandler.Exists(catchKey);
            if (exist)
            {
                entitys = this._catchHandler.Get<List<SystemPermission>>(catchKey);
            }
            else
            {
                entitys = await _dataContext.SystemPermissions.Where(x => !x.Deleted).ToListAsync();
                this._catchHandler.Add(catchKey, entitys);
            }
            return entitys;

        }

        public async Task<List<SystemRole>> GetRoleEntitys()
        {
            var entitys = new List<SystemRole>();
            var catchKey = "RoleEntitys";
            var exist = this._catchHandler.Exists(catchKey);
            if (exist)
            {
                entitys = this._catchHandler.Get<List<SystemRole>>(catchKey);
            }
            else
            {
                entitys = await _dataContext.SystemRoles.Where(x => !x.Deleted).ToListAsync();
                this._catchHandler.Add(catchKey, entitys);
            }
            return entitys;

        }

        public async Task<List<SystemRolePermission>> GetRolePerssionEntitys(Guid roleId)
        {
            var entitys = new List<SystemRolePermission>();
            var catchKey = roleId.ToString();
            var exist = this._catchHandler.Exists(catchKey);
            if (exist)
            {
                entitys = this._catchHandler.Get<List<SystemRolePermission>>(catchKey);
            }
            else
            {
                entitys = await _dataContext.SystemRolePermissions.Where(x => !x.Deleted && x.RoleId == roleId).ToListAsync();
                this._catchHandler.Add(catchKey, entitys);
            }
            return entitys;

        }

        public SystemRole GetRoleInfo(Guid id)
        {
            try
            {
                var sql = "SELECT TOP 1 * FROM [SystemRole] WHERE [Id] = @Id";
                var role =  _dapperContext.Conn.QueryFirstOrDefault<SystemRole>(sql,new {Id = id});

                if (role == null)
                {
                    throw new ArgumentException("未获取到角色信息");
                }

                return role;
            }
            catch (Exception ex )
            {
                throw ex;
            }
        }

        public ViewAccountList GetUserInfo(Guid id)
        {
            try
            {
                var sql = "SELECT TOP 1 * FROM [ViewAccountList] WHERE [Id] = @Id";
                var role = _dapperContext.Conn.QueryFirstOrDefault<ViewAccountList>(sql, new { Id = id });

                if (role == null)
                {
                    throw new ArgumentException("未获取到用户信息");
                }

                return role;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

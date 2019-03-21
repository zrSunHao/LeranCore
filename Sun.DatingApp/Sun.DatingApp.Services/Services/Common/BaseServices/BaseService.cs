using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Utility.CacheUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sun.DatingApp.Services.Services.Common.BaseServices
{
    public abstract class BaseService: IBaseService
    {
        public readonly DataContext _dataContext;
        public readonly IMapper _mapper;
        public readonly ICacheHandler _catchHandler;

        public Guid? CurrentUserId = null;
        private DataContext dataContext;
        private IMapper mapper;

        public BaseService(
            DataContext dataContext,
            IMapper mapper,
            ICacheHandler catchService
            )
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _catchHandler = catchService;
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

        public async Task<List<Permission>> GetPerssionEntitys()
        {
            var entitys = new List<Permission>();
            var catchKey = "PerssionEntitys";
            var exist = this._catchHandler.Exists(catchKey);
            if (exist)
            {
                entitys = this._catchHandler.Get<List<Permission>>(catchKey);
            }
            else
            {
                entitys = await _dataContext.Permissions.Where(x => !x.Deleted).ToListAsync();
                this._catchHandler.Add(catchKey, entitys);
            }
            return entitys;

        }

        public async Task<List<Role>> GetRoleEntitys()
        {
            var entitys = new List<Role>();
            var catchKey = "RoleEntitys";
            var exist = this._catchHandler.Exists(catchKey);
            if (exist)
            {
                entitys = this._catchHandler.Get<List<Role>>(catchKey);
            }
            else
            {
                entitys = await _dataContext.Roles.Where(x => !x.Deleted).ToListAsync();
                this._catchHandler.Add(catchKey, entitys);
            }
            return entitys;

        }

        public async Task<List<RolePermission>> GetRolePerssionEntitys(Guid roleId)
        {
            var entitys = new List<RolePermission>();
            var catchKey = roleId.ToString();
            var exist = this._catchHandler.Exists(catchKey);
            if (exist)
            {
                entitys = this._catchHandler.Get<List<RolePermission>>(catchKey);
            }
            else
            {
                entitys = await _dataContext.RolePermissions.Where(x => !x.Deleted && x.RoleId == roleId).ToListAsync();
                this._catchHandler.Add(catchKey, entitys);
            }
            return entitys;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Data.Entities;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Utility.CacheUtility;

namespace Sun.DatingApp.Services.Services.BaseServices
{
    public abstract class BaseService: IBaseService
    {
        public readonly DataContext _dataContext;
        public readonly IMapper _mapper;
        public readonly ICacheService _catchService;

        public Guid? CurrentUserId = null;
        private DataContext dataContext;
        private IMapper mapper;

        public BaseService(
            DataContext dataContext,
            IMapper mapper,
            ICacheService catchService
            )
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _catchService = catchService;
        }

        public void SetCurrentUserId(Guid? id)
        {
            this.CurrentUserId = id;
        }

        /// <summary>
        /// 获取当前登录用户
        /// </summary>
        public virtual Account CurrentUser
        {
            get
            {
                if (CurrentUserId.HasValue)
                {
                    return _dataContext.Accounts.FirstOrDefault(x => x.Id == CurrentUserId);
                }
                return null;
            }
        }

        public async Task<List<Permission>> GetPerssionEntitys()
        {
            var entitys = new List<Permission>();
            var catchKey = "PerssionEntitys";
            var exist = this._catchService.Exists(catchKey);
            if (exist)
            {
                entitys = this._catchService.Get<List<Permission>>(catchKey);
            }
            else
            {
                entitys = await _dataContext.Permissions.Where(x => !x.Deleted).ToListAsync();
                this._catchService.Add(catchKey, entitys);
            }
            return entitys;

        }
    }
}

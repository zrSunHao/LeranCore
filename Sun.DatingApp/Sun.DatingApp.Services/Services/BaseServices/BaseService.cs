using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Data.Entities;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Services.Services.BaseServices
{
    public abstract class BaseService: IBaseService
    {
        public readonly DataContext _dataContext;
        public readonly IMapper _mapper;

        public Guid? CurrentUserId = null;

        public BaseService(
            DataContext dataContext,
            IMapper mapper
            )
        {
            _dataContext = dataContext;
            _mapper = mapper;
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
    }
}

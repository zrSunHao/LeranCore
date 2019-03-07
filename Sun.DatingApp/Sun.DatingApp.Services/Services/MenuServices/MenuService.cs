using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Services.Services.BaseServices;
using Sun.DatingApp.Utility.CacheUtility;

namespace Sun.DatingApp.Services.Services.MenuServices
{
    public class MenuService : BaseService, IMenuService
    {
        public MenuService(DataContext dataContext, IMapper mapper, ICacheService catchService) : base(dataContext, mapper, catchService)
        {
        }


    }
}

using AutoMapper;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Services.Services.Common.BaseServices;
using Sun.DatingApp.Services.Services.UserServices;
using Sun.DatingApp.Utility.CacheUtility;

namespace Sun.DatingApp.Services.Services.System.UserServices
{
    public class UserService : BaseService, IUserService
    {
        public UserService(DataContext dataContext, IMapper mapper, ICacheHandler catchHandler) : base(dataContext, mapper, catchHandler)
        {

        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Services.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sun.DatingApp.Model.Auth.Accounts.Dto;
using Sun.DatingApp.Model.Auth.Accounts.Model;

namespace Sun.DatingApp.Services.Services.UserServices
{
    public class UserService : BaseService, IUserService
    {
        public UserService(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Services.Services.BaseServices;

namespace Sun.DatingApp.Services.Services.RoleServices
{
    public class RoleService: BaseService,IRoleService
    {
        public RoleService(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }
    }
}

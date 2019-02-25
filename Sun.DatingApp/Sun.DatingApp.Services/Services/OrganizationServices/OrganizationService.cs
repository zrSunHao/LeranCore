using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Services.Services.BaseServices;

namespace Sun.DatingApp.Services.Services.OrganizationServices
{
    public class OrganizationService: BaseService, IOrganizationService
    {
        public OrganizationService(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }
    }
}

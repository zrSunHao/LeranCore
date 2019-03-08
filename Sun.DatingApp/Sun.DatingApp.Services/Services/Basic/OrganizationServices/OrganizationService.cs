using AutoMapper;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Services.Services.Common.BaseServices;
using Sun.DatingApp.Utility.CacheUtility;

namespace Sun.DatingApp.Services.Services.Basic.OrganizationServices
{
    public class OrganizationService: BaseService, IOrganizationService
    {
        public OrganizationService(DataContext dataContext, IMapper mapper, ICacheService catchService) : base(dataContext, mapper, catchService)
        {
        }
    }
}

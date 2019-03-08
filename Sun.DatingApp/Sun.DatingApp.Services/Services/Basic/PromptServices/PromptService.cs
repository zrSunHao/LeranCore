using AutoMapper;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Services.Services.Common.BaseServices;
using Sun.DatingApp.Utility.CacheUtility;

namespace Sun.DatingApp.Services.Services.Basic.PromptServices
{
    public class PromptService: BaseService, IPromptService
    {
        public PromptService(DataContext dataContext, IMapper mapper, ICacheHandler catchHandler) : base(dataContext, mapper, catchHandler)
        {
        }
    }
}

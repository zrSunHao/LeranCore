using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Sun.DatingApp.Api.Extensions.Authorization;
using Sun.DatingApp.Utility.CacheUtility;

namespace Sun.DatingApp.Api.Config
{
    public static class HandlerConfigExtensions
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICacheService, MemoryCacheService>();

            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
        }

        public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}

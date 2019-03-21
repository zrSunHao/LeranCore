using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Sun.DatingApp.Services.Services.Basic.OrganizationServices;
using Sun.DatingApp.Services.Services.Basic.PromptServices;
using Sun.DatingApp.Services.Services.System.AuthServices;
using Sun.DatingApp.Services.Services.System.MenuServices;
using Sun.DatingApp.Services.Services.System.Permissions;
using Sun.DatingApp.Services.Services.System.RoleServices;
using Sun.DatingApp.Services.Services.System.UserServices;

namespace Sun.DatingApp.Api.Config
{
    public static class ServicesConfigExtensions
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IPromptService, PromptService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IMenuService, MenuService>();
        }

        public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Services.SignalRHubs;

namespace Sun.DatingApp.Api.Config
{
    public static class SettingConfigExtensions
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("Default");
                options.UseSqlServer(connectionString);
            });

            //配置AutoMapper
            services.AddAutoMapper();

            //跨域配置
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularDevOrigin",
                    builder => builder
                        //.WithOrigins("http://localhost:4200")
                        //.WithExposedHeaders("X-Pagination")
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            services.AddSignalR();

            //配置缓存
            services.AddMemoryCache();

            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });
        }

        public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //跨域
            app.UseCors("AllowAngularDevOrigin");

            app.UseSignalR(routes =>
            {
                routes.MapHub<TaskHub>("/taskhub");//taskhub供前端调用
            });
        }
    }
}

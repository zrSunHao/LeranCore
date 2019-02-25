using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Services.Services.AuthServices;
using Sun.DatingApp.Services.Services.UserServices;
using Sun.DatingApp.Services.SignalRHubs;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using Sun.DatingApp.Api.Extensions.Authorization;
using Sun.DatingApp.Services.Services.OrganizationServices;
using Sun.DatingApp.Services.Services.PromptServices;
using Sun.DatingApp.Services.Services.RoleServices;
using Sun.DatingApp.Utility.CacheUtility;

namespace Sun.DatingApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region 配置

            services.AddDbContext<DataContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("Default");
                options.UseSqlServer(connectionString);
            });

            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie();

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

            //添加访问权限验证
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            //注册Swagger生成器，定义一个和多个Swagger 文档
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "第一版 API",
                    Description = "第一版 ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "孙浩",
                        Email = "2080680175@qq.com",
                        Url = "https://github.com/zrSunHao"
                    },
                    License = new License
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    },
                });

                option.SwaggerDoc("v2", new Info
                {
                    Version = "v2",
                    Title = "第二版 API",
                    Description = "第二版 ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "孙浩",
                        Email = "2080680175@qq.com",
                        Url = "https://github.com/zrSunHao"
                    },
                    License = new License
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    }
                });

                option.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datingApi.Swagger.xml"));

                //添加header验证信息
                //c.OperationFilter<SwaggerHeader>();
                var security = new Dictionary<string, IEnumerable<string>> { { "Bearer", new string[] { } }, };
                option.AddSecurityRequirement(security);//添加一个必须的全局安全信息，和AddSecurityDefinition方法指定的方案名称要一致，这里是Bearer。
                option.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 参数结构: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = "header",//jwt默认存放Authorization信息的位置(请求头中)
                    Type = "apiKey"
                });

            });

            services.AddSignalR();

            //配置缓存
            services.AddMemoryCache();

            #endregion

            #region Service注册
            //缓存
            services.AddSingleton<IMemoryCache>(factory =>
           {
               var cache = new MemoryCache(new MemoryCacheOptions());
               return cache;
           });
            services.AddSingleton<ICacheService, MemoryCacheService>();

            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();

            //系统
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IPromptService, PromptService>();
            services.AddScoped<IRoleService, RoleService>();

            //
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //跨域
            app.UseCors("AllowAngularDevOrigin");

            //访问权限
            app.UseAuthentication();

            //启用中间件服务生成Swagger作为JSON终结点
            app.UseSwagger();
            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V2");
            });
            
            app.UseSignalR(routes =>
            {
                routes.MapHub<TaskHub>("/taskhub");//taskhub供前端调用
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

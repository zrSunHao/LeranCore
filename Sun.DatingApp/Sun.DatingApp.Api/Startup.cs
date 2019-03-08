using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sun.DatingApp.Api.Config;

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
            AuthorizationConfigExtensions.ConfigureServices(services, Configuration);

            SwaggerConfigExtensions.ConfigureServices(services);

            ServicesConfigExtensions.ConfigureServices(services);

            HandlerConfigExtensions.ConfigureServices(services);

            SettingConfigExtensions.ConfigureServices(services, Configuration);

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

            AuthorizationConfigExtensions.Configure(app, env);

            SwaggerConfigExtensions.Configure(app, env);

            ServicesConfigExtensions.Configure(app, env);

            HandlerConfigExtensions.Configure(app, env);

            SettingConfigExtensions.Configure(app, env);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

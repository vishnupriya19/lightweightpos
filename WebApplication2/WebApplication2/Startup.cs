using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication2.Model;

namespace WebApplication2
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
             _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));
            services.AddMvc().AddXmlSerializerFormatters();
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            services.AddScoped<IDesignationRepository, SQLDesignationRepository>();
            services.AddScoped<IMerchantRepository, SQLMerchantRepository>();
            //services.AddAuthentication("BasicAuthentication")
              //  .AddScheme<AuthenticationSchemeOptions, UserBasicAuthenticationHandler>("BasicAuthentication", null);
            services.AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseMvcWithDefaultRoute();
            //app.UseMvc(routes =>
            //{
            //  routes.MapRoute("default", "{controller}/{action}/{id?}");
            //});
            //app.UseAuthentication();
            app.UseMvc();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(_config["MyKey"]);
            });
        }
    }
}

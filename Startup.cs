using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using DutchTreat.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace DutchTreat
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMailService, NullMailService>();

            services.Configure<DutchTreatDatabaseSettings>(cfg =>
            {
                cfg.ConnectionString = Configuration.GetSection("ConnectionStrings:ConnectionString").Value;
                cfg.DatabaseName = Configuration.GetSection("ConnectionStrings:DatabaseName").Value;
            });

            services.AddSingleton<IDutchContext, DutchContext>();

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(cfg =>
            {
                cfg.MapRazorPages();

                cfg.MapControllerRoute("Default",
                    "/{controller}/{action}/{id?}",
                    new { controller = "App", action = "Index" });
            });
        }
    }
}

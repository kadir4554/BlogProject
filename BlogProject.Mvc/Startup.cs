using BlogProject.Services.AutoMapper.Profiles;
using BlogProject.Services.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Mvc
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();//��lemlerimizi kaydettikten sonra g�rebilece�iz. S�rekli yeniden derlememize gerek kalmad�
            services.AddAutoMapper(typeof(CategoryProfile),typeof(ArticleProfile));
            services.LoadMyServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseStaticFiles();//static dosyalar� kullanmam�z� sa�lar
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                                
                    endpoints.MapAreaControllerRoute(
                        name: "Admin",
                        areaName: "Admin",
                        pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                        );
                    endpoints.MapDefaultControllerRoute();//Sitemiz a��ld���nda otomatik olarak homecontroller ve index gider.
                   
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using JMS.Service;
using Microsoft.EntityFrameworkCore;
using JMS.Data;
using JMS.Data.Interfaces;
using JMS.Data.Repositories;
using Microsoft.AspNetCore.Identity;

namespace JMS
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        
        public void ConfigureServices(IServiceCollection services)
        {
            //подключаем конфиг из appsettings.json
            Configuration.Bind("Project", new Config());

            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(Config.ConnectionString));
            
            //настраиваем identity систему
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();

            services.AddTransient<IUsers, UsersRepository>();
            services.AddTransient<ITasks, TasksRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContext appDBContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                AppDBContext.Initial(appDBContext);
            }*/
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // ригистрация маршрутов
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

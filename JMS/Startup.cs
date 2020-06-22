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

namespace JMS
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        
        public void ConfigureServices(IServiceCollection services)
        {
            //���������� ������ �� appsettings.json
            Configuration.Bind("Project", new Config());

            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(Config.ConnectionString));
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

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContext appDBContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                AppDBContext.Initial(appDBContext);
            }
            app.UseStaticFiles();
            app.UseRouting();

            // ����������� ���������
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.BusinessLayer.Logics;
using WebAPI.DataLayer.DatabaseContext;
using WebAPI.DataLayer.Repositorys;
using WebAPI.DataLayer.UnitOfWork;
using WebAPI.Domain.Interfaces.Logics;
using WebAPI.Domain.Interfaces.Repositorys;
using WebAPI.Domain.Interfaces.UnitofWork;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();            
            InitDbContext(services);
            AddRepositorys(services);
            AddLogics(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, LocalContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            dbContext.Database.EnsureCreated();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void InitDbContext(IServiceCollection services)
        {
            services.AddDbContext<LocalContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(LocalContext).Assembly.FullName)));
        }

        private void AddRepositorys(IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IAccountRepository, AccountRepository>();
        }

        private void AddLogics(IServiceCollection services)
        {
            services.AddScoped<IAccountLogic, AccountLogic>();
        }

    }
}

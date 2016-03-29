using System;
using Microsoft.AspNet.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.DependencyInjection;
using ClicouMandou.Infrastructure.Data.Context;
using ClicouMandou.Infrastructure.Data.Domain.UserArg;
using Microsoft.Data.Entity;
using ClicouMandou.Infrastructure.Data.Domain.ProjetoArg;

namespace ClicouMandou.Infrastructure.Data
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddEntityFramework()
            .AddSqlServer()
            .AddDbContext<ClicouMandouDbContext>();

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ClicouMandouDbContext, Guid>()
                .AddDefaultTokenProviders();

            services.AddScoped<DbContext, ClicouMandouDbContext>();
        }
        public void Configure(IApplicationBuilder app)
        {

        }
    }
}

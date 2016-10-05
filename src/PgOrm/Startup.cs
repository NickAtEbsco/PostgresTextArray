using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using PgOrm.EntityObjects.List;
using PgOrm.EntityObjects.Array;

namespace PgOrm
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			var sqlConnectionString = Configuration["DataAccessPostgreSqlProvider:ConnectionString"];

			// Create the ListDbContext
			services.AddDbContext<ListDbContext>(options =>
				options.UseNpgsql(
					sqlConnectionString,
					b => b.MigrationsAssembly("AspNet5MultipleProject")
				)
			);

			// Create the ListDbContext
			services.AddDbContext<ArrayDbContext>(options =>
				options.UseNpgsql(
					sqlConnectionString,
					b => b.MigrationsAssembly("AspNet5MultipleProject")
				)
			);

			// Add framework services.
			services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

			app.UseDeveloperExceptionPage();

			app.UseMvc();
        }
    }
}

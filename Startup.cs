using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ColourAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ColourAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }


        public void ConfigureServices(IServiceCollection services)
        {
            //var server = "sql_server";
            var server = "127.0.0.1";
            //var server = "localhost";
            //var server = Configuration["DBServer"] ?? "localhost";
            //var server = Configuration["DBServer"] ?? "ms-sql-server";
            //var port = Configuration["DBPort"] ?? "1433";
            var port = "1433";
            var user = Configuration["DBUser"] ?? "sa";
            var password = Configuration["DBPassword"] ?? "Aa30597131972_";
            var database = Configuration["Database"] ?? "Colours";

            services.AddDbContext<ColourContext>(options =>
                options.UseSqlServer($"Server={server},{port};Database={database};User={user};Password={password}")
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
            PrepDB.PrePopulation(app);
        }
    }
}

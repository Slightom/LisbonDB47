using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LisbonDB47.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LisbonDB47
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
            //var connection = @"Server=(localdb)\mssqllocaldb;Database=LisbonDB47;Trusted_Connection=True;ConnectRetryCount=0";
            // services.AddDbContext<LisbonDbContext>(options => options.UseSqlServer(connection));
            var connection = "User ID=slightom;Password=carpediem1020;Host=localhost;Port=5432;Database=lisbonDB47;Pooling=true;";
            services.AddDbContext<LisbonDbContext>(options => options.UseNpgsql(connection));
            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

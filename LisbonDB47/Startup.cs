using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LisbonDB47.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

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
            var connection = "User ID=slightom;Password=carpediem1020;Host=localhost;Port=5432;Database=lisbondb47;Pooling=true;";
            services.AddDbContext<LisbonDbContext>(options => options.UseNpgsql(connection));

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("212.237.17.69"));
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddSwaggerGen(options =>
            //{
            //    var basePath = AppContext.BaseDirectory;
            //    var assemblyName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            //    var fileName = System.IO.Path.GetFileName(assemblyName + ".xml");
            //    //Set the comments path for the swagger json and ui.
            //    options.IncludeXmlComments(System.IO.Path.Combine(basePath, fileName));
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, LisbonDbContext context)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });


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

            DbInitializer.SeedData(context);

            //app.UseSwagger();
            //app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My simple API"); });
        }
    }
}

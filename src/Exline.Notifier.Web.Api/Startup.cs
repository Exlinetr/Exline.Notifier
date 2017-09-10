using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Exline.Notifier.Web.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            var config = new Config().SetDbServer(new DbServer()
            {
                DatabaseName = Environment.GetEnvironmentVariable("dbName"),
                Host = Environment.GetEnvironmentVariable("dbServer"),
                Password = Environment.GetEnvironmentVariable("dbPassword"),
                Username = Environment.GetEnvironmentVariable("dbUser"),
                Port = int.Parse(Environment.GetEnvironmentVariable("dbPort")),
                Type = DbType.Mongodb,
                TimeOut = new TimeSpan(0, 0, 0, 10)
            }).SetLogPath(Environment.GetEnvironmentVariable("logpath"));
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc().UseRouter(x =>
            {
                x.MapRoute("default", "/", new
                {
                    controller = "home",
                    action = "index"
                });
            });
        }
    }
}

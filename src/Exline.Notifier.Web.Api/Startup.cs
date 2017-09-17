using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Exline.Notifier.Web.Api
{
    public class Startup
    {
        public static Config Config { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            Config = new Config()
                .SetDbServer(new DbServer()
                {
                    DatabaseName = Environment.GetEnvironmentVariable("dbName"),
                    Host = Environment.GetEnvironmentVariable("dbServer"),
                    Port = int.Parse(Environment.GetEnvironmentVariable("dbPort")),
                    Username = Environment.GetEnvironmentVariable("dbUser"),
                    Password = Environment.GetEnvironmentVariable("dbPassword"),
                    Type = DbType.Mongodb,
                    TimeOut = new TimeSpan(0, 0, 0, 10),
                })
            .SetLogPath(Environment.GetEnvironmentVariable("logpath"));
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services
                .AddMvc(options =>
                {
                })
                .AddJsonOptions(jsonOptions =>
                {
                    jsonOptions.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
                    jsonOptions.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=notification}/{action=index}");
            });
        }
    }
}

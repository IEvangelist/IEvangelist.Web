using IEvangelist.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Model;
using static System.IO.Directory;
using static System.IO.Path;
using static Microsoft.Net.Http.Headers.HeaderNames;

namespace IEvangelistWeb
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        internal static IWebHost BuildWebHost()
            => new WebHostBuilder()
                   .UseKestrel()
                   .UseContentRoot(GetCurrentDirectory())
                   .UseIISIntegration()
                   .UseStartup<Startup>()
                   .Build();

        public Startup(IHostingEnvironment env)
        {
            Configuration =
                new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables()
                    .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Title = "IEvangelist.Web API",
                    Version = "v1"
                });
            });

            // Add framework services.
            services.AddMvc();
            services.AddResponseCompression(
                options => options.MimeTypes = ResponseCompressionMimeTypes.Defaults);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env, 
                              ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
            }

            const string node_modules = nameof(node_modules);

            app.UseResponseCompression()
               .UseSwagger()
               .UseSwaggerUi()
               .UseStaticFiles()
               .UseStaticFiles(new StaticFileOptions
               {
                   FileProvider = new PhysicalFileProvider(Combine(env.ContentRootPath, node_modules)),
                   RequestPath = $"/{node_modules}",
                   OnPrepareResponse = 
                       _ => _.Context.Response.Headers[CacheControl] = "public,max-age=604800"
               })
               .UseMvc(routes =>
               {
                   routes.MapSpaFallbackRoute("spa-fallback", 
                                              new { controller = "home", action = "index" });
               });
        }
    }
}
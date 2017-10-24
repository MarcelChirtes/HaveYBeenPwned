using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace HibpProxy
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
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Configuration["SwaggerApiDescription:Version"], 
                    new Info
                    {
                        Title = Configuration["SwaggerApiDescription:Name"],
                        Version = Configuration["SwaggerApiDescription:Version"],
                        Description = Configuration["SwaggerApiDescription:Description"],
                        //TermsOfService = Configuration["SwaggerApiDescription.TermsOfService"],
                        License = new License
                        {
                            Name = "Creative Commons Attribution 4.0 International License",
                            Url = "https://creativecommons.org/licenses/by/4.0/"
                        },
                    });

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "HibpProxy.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages("text/plain", "Status code page, status code: {0}");

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{Configuration["SwaggerApiDescription:Version"]}/{Configuration["SwaggerApiDescription:SwaggerDescriptorFile"]}", Configuration["SwaggerApiDescription:Name"]);
                c.InjectStylesheet("/swagger-ui/custom.css");
            });

            app.UseMvc();

        }
    }
}

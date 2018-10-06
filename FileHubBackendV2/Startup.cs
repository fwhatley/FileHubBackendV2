using FileHubBackendV2.Repositories;
using FileHubBackendV2.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace FileHubBackendV2
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            try
            {

                // Register the Swagger generator, defining 1 or more Swagger documents
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                    c.ExampleFilters();

                    c.OperationFilter<AddFileParamTypesOperationFilter>(); // Adds an UploadFile button to endpoints which have [AddSwaggerFileUploadButton]
                    c.OperationFilter<AddHeaderOperationFilter>("correlationId", "Correlation Id for the request"); // adds any string you like to the request headers - in this case, a correlation id
                    c.OperationFilter<AddResponseHeadersFilter>(); // [SwaggerResponseHeader]
                    c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>(); // Adds "(Auth)" to the summary so that you can see which endpoints have Authorization
                    // or use the generic method, e.g. c.OperationFilter<AppendAuthorizeToSummaryOperationFilter<MyCustomAttribute>>();

                });
                services.AddSwaggerExamples();

                services.AddMvc();
                services.AddScoped<ICitiesService, CitiesService>();
                services.AddScoped<IFilesService, FilesService>();
                services.AddSingleton<ICitiesRepository, CitiesRepository>();
                //services.AddSingleton<IFilesRepository, FakeFilesRepository>();
                services.AddSingleton<IFilesRepository, FilesRepository>();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint. 
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            loggerFactory.AddConsole();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseMvc();

            // let mvc handle everything
            /*app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });*/
        }
    }
}

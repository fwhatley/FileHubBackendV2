using FileHubBackendV2.Repositories;
using FileHubBackendV2.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.PostgreSQL;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace FileHubBackendV2
{
    public class Startup
    {
        public readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            try
            {

                // Add cors: https://stackoverflow.com/questions/31942037/how-to-enable-cors-in-asp-net-core
                services.AddCors(options =>
                {
                    options.AddPolicy("AllowAll",
                        builder =>
                        {
                            builder
                                .AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials();
                        });
                });

                // Register the Swagger generator, defining 1 or more Swagger documents
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                    c.ExampleFilters();

                    c.OperationFilter<AddFileParamTypesOperationFilter>(); // Adds an CreateFile button to endpoints which have [AddSwaggerFileUploadButton]
                    c.OperationFilter<AddHeaderOperationFilter>("correlationId", "Correlation Id for the request"); // adds any string you like to the request headers - in this case, a correlation id
                    c.OperationFilter<AddResponseHeadersFilter>(); // [SwaggerResponseHeader]
                    c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>(); // Adds "(Auth)" to the summary so that you can see which endpoints have Authorization
                    // or use the generic method, e.g. c.OperationFilter<AppendAuthorizeToSummaryOperationFilter<MyCustomAttribute>>();

                });
                services.AddSwaggerExamples();

                services.AddMvc();
                services.AddSingleton(Configuration); // Whenever we use IConfigration there we are going to get instance of Configuration: https://www.c-sharpcorner.com/article/setting-and-reading-values-from-app-settings-json-in-net-core/
                services.AddScoped<IFileRecordsService, FileRecordsService>();
                //services.AddSingleton<IFileRecordsRepository, FakeFilesRepository>(); // TODO: use for testing, not needed if inmemory db is used
                //services.AddSingleton<IFileRecordsRepository, FilesEfRepository>(); // Enable this if you want to use EF
                services.AddSingleton<IFileRecordsRepository, FileRecordsPgRepository>(); // Enable this if you want to use OrmLite

                // set up db OrmLite with Postgres
                // used reference: https://github.com/ServiceStack/ServiceStack.OrmLite
                var connectionString = Configuration.GetValue<string>("Data:ConnectionStrings:PgSqlDatabase");
                var dbFactory = new OrmLiteConnectionFactory(connectionString, new PostgreSqlDialectProvider()
                {
                    NamingStrategy = new OrmLiteNamingStrategyBase()
                });

                services.AddSingleton<IDbConnectionFactory>(dbFactory);

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

            // Use my cors policy
            // Enable cors for any call: https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-2.1, make sure to add cservices.AddCors(); in ConfigureServices() before
            app.UseCors("AllowAll");

            // For the wwwroot folder
            app.UseStaticFiles();

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

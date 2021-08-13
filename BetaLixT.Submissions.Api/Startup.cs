using FluentValidation.AspNetCore;
using BetaLixT.Submissions.Api.Authentication;
using BetaLixT.Submissions.Api.Setup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using BetaLixT.Submissions.Common;

namespace BetaLixT.Submissions.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // - This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // - Setting up authentication services
            // services.RegisterJwtAuthenticationService(Configuration.GetSection("JwtConfig"), PolicyNames.AzureAuth);
            services.RegsiterApiKeyAuthenticationService(Configuration.GetSection("ApiKeyConfig"), PolicyNames.JobApiKey);

            // - Setting
            services.AddControllers();
            services.AddCors(options => options.AddDefaultPolicy(
               builder =>
               {
                   builder
                       .WithOrigins(
                          "https://betalixt.com"
                          )
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials();
               }));

            // - DI
            services.RegisterDatabaseService(Configuration.GetSection("ConnectionStrings")["DatabaseConnection"]);
            services.RegisterApiServices();

            // - Model validation service
            services.AddMvc().AddFluentValidation();

            // - Adding Swagger service
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BetaLixT Submissions API",
                    Description = "Submissions portal"
                });

                // Set the comments path for the Swagger JSON and UI.
            });
        }

        // - This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseAuthorization();
            
            // - Global error handling
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // - Adding Swagger to pipeline
            app.UseSwagger();
            app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "api"));
        }
    }
}

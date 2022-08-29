using Api.Extensions;
using AspMovie.Api.Core;
using AspMovie.Application.Emails;
using AspMovie.Application.Logging;
using AspMovie.Implementation;
using Implementation.Emails;
using Implementation.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace AspMovie.Api
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
            var settings = new AppSettings();

            Configuration.Bind(settings);

            services.AddSingleton(settings);
            services.AddApplicationUser();
            services.AddJwt(settings);
            services.AddProjectDbContext();
            services.AddUseCases();

            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
            services.AddTransient<IUseCaseLogger>(x => new SpUseCaseLogger(settings.ConnString));
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<IEmailSender>(x => new SmtpEmailSender(
                    settings.EmailOptions.FromEmail,
                    settings.EmailOptions.Password,
                    settings.EmailOptions.Port,
                    settings.EmailOptions.Host)
            );
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspMovie.Api", Version = "v1" });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AspMovie.Api v1"));
            }

            app.UseRouting();
            app.UseMiddleware<GlobalExceptionHandler>();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

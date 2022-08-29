using AspMovie.Api.Core;
using AspMovie.Application.UseCases.Commands;
using AspMovie.Application.UseCases.Queries;
using AspMovie.DataAccess;
using AspMovie.Domain;
using AspMovie.Implementation.UseCases.Commands.Ef;
using AspMovie.Implementation.UseCases.Queries.Ef;
using AspMovie.Implementation.UseCases.Queries.Sp;
using AspMovie.Implementation.Validators;
using AspMovie.UseCases.Commands.Ef;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Extensions
{
    public static class ContainerExtensions
    {
        /// <summary>
        /// Jwt Authentification
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settings"></param>
        public static void AddJwt(this IServiceCollection services, AppSettings settings)
        {
            services.AddTransient(x =>
            {
                var context = x.GetService<ProjectDbContext>();
                var settings = x.GetService<AppSettings>();

                return new JwtManager(settings.JwtSettings, context);
            });


            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.JwtSettings.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        /// <summary>
        /// use cases - query,commands,validators
        /// </summary>
        /// <param name="services"></param>
        public static void AddUseCases(this IServiceCollection services)
        {
            #region Queries
            services.AddTransient<IGetGenresQuery, EfGetGenresQuery>();
            services.AddTransient<IGetMoviesQuery, EfGetMoviesQuery>();
            services.AddTransient<IGetActorsQuery, EfGetActorsQuery>();
            services.AddTransient<IGetUseCaseLogsQuery, GetUseCaseLogsQuery>();
            #endregion

            #region Commands
            services.AddTransient<IAddCrewsCommand, EfAddCrewsCommand>();
            services.AddTransient<IRateMovieCommand, EfRateMovieCommand>();
            services.AddTransient<ICreateGenreCommand, EfCreateGenreCommand>();
            services.AddTransient<IDeleteGenreCommand, EfDeleteGenreCommand>();
            services.AddTransient<IUpdateGenreCommand, EfUpdateGenreCommand>();
            services.AddTransient<ICreateActorCommand, EfCreateActorCommand>();
            services.AddTransient<IDeleteActorCommand, EfDeleteActorCommand>();
            services.AddTransient<ICreateMovieCommand, EfCreateMovieCommand>();
            services.AddTransient<IRegisterUserCommand,EfRegisterUserCommand>();
            services.AddTransient<IAddMovieCastCommand, EfAddMovieCastCommand>();
            services.AddTransient<IUpdateUserUseCasesCommand, EfUpdateUserUseCasesCommand>();
            #endregion

            #region Validators
            services.AddTransient<CrewValidator>();
            services.AddTransient<CastValidator>();
            services.AddTransient<GenreValidator>();
            services.AddTransient<ActorValidator>();
            services.AddTransient<MovieValidator>();
            services.AddTransient<RatingValidator>();
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<UpdateUserUseCasesValidator>();
            services.AddTransient<SearchUseCaseLogsValidator>();
            #endregion
        }
        /// <summary>
        /// App user - check login param
        /// </summary>
        /// <param name="services"></param>
        public static void AddApplicationUser(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUser>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var header = accessor.HttpContext.Request.Headers["Authorization"];

                var claims = accessor.HttpContext.User;

                if (claims == null || claims.FindFirst("UserId") == null)
                {
                    return new AnonimousUser();
                }

                var actor = new JwtUser
                {
                    Email = claims.FindFirst("Email").Value,
                    Id = Int32.Parse(claims.FindFirst("UserId").Value),
                    Identity = claims.FindFirst("Email").Value,
                    UseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value)
                };

                return actor;
            });
        }


        /// <summary>
        /// Database connection
        /// </summary>
        /// <param name="services"></param>
        public static void AddProjectDbContext(this IServiceCollection services)
        {
            services.AddTransient(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder();

                var conString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AspMovie;Integrated Security=True";
                // ovde gadja error kad pozivam servis appsetting i njegov prop connstring!!

                optionsBuilder.UseSqlServer(conString).UseLazyLoadingProxies();

                var options = optionsBuilder.Options;

                return new ProjectDbContext(options);
            });
        }


    }
}

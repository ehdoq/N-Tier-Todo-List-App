using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TodoList.Extension.Filters;
using TodoList.Extension.Handlers;
using TodoList.Extension.Modules;
using TodoList.Repository.AppDBContexts;
using TodoList.Service.Mapping;
using TodoList.Service.Validations;

namespace TodoList.Extension.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                                                builder.AllowAnyOrigin()
                                                       .AllowAnyMethod()
                                                       .AllowAnyHeader());
            });

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) =>
           services.AddDbContext<AppDbContext>(x =>
           {
               x.UseSqlServer(configuration.GetConnectionString("sqlCon"), options =>
               {
                   options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext))?.GetName().Name);
               });
           });

        public static void ConfigureFluentValidation(this IServiceCollection services) =>
            services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute()))
                    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<UserDtoValidator>())
                    .AddJsonOptions(options => 
                    { 
                        options.JsonSerializerOptions.PropertyNamingPolicy = null; //JSON First Letter Uppercase
                    }); 

        public static void ConfigureModelStateInvalidFilter(this IServiceCollection services) =>
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

        public static void ConfigureAutoMapper(this IServiceCollection services)
            => services.AddAutoMapper(typeof(MapProfile));

        public static void ConfigureAutofac(this IServiceCollection services, WebApplicationBuilder builder)
            => builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(cB => cB.RegisterModule(new AutofacModule()));

        public static void ConfigureNotFoundFilter(this IServiceCollection services)
           => services.AddScoped(typeof(NotFoundFilter<>));

        public static void ConfigureAuthentication(this IServiceCollection services)
           => services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

        public static void ConfigureSwaggerGen(this IServiceCollection services)
            => services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Web API", Version = "v1" });

                s.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        new string[]{}
                    }
                });
            });
    }
}
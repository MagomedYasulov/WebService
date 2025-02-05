using FluentValidation.AspNetCore;
using FluentValidation;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebService.Data;
using WebService.Validators;
using WebService.Models;
using Newtonsoft.Json.Serialization;
using WebService.Abstractions;
using WebService.Services;
using WebService.Middlewares;

namespace WebService.Extentions
{
    public static class ServiceCollectionsExtensions
    {
        public static WebApplicationBuilder AddData(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationContext>(opt =>
                opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); //opt.UseInMemoryDatabase("WebServiceDb")); //opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            return builder;
        }

        public static WebApplicationBuilder AddControllers(this WebApplicationBuilder builder)
        {
            builder.Services.AddRouting(opt => opt.LowercaseUrls = true);
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            return builder;
        }

        public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WebService API",
                    Version = "v1"
                });
            });

            return builder;
        }

        public static WebApplicationBuilder AddFluentValidation(this WebApplicationBuilder builder)
        {
            builder.Services.AddFluentValidationRulesToSwagger();
            builder.Services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();
            builder.Services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
            });
            return builder;
        }

        public static WebApplicationBuilder AddAutoMapper(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(cfg => cfg.AddProfile(new AutoMapperProfile()));
            return builder;
        }

        public static WebApplicationBuilder AddSignalR(this WebApplicationBuilder builder)
        {
            builder.Services.AddSignalR()
            .AddNewtonsoftJsonProtocol(options =>
            {
                options.PayloadSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            return builder;
        }

        public static WebApplicationBuilder AddAppServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IMessagesService, MessageServie>();
            return builder;
        }

        public static WebApplicationBuilder AddExceptionHandler(this WebApplicationBuilder builder)
        {
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();
            return builder;
        }

    }
}

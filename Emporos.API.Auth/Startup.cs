using System;
using System.Data;
using System.IO;
using System.Reflection;
using AutoMapper;
using Emporos.API.Auth.Common.Settings;
using Emporos.API.Auth.Domain.Contracts;
using Emporos.API.Auth.Domain.Internal;
using Emporos.API.Auth.Infraestructure;
using Emporos.API.Auth.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Emporos.API.Auth.Common.Attributtes;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Emporos.API.Auth.Controllers.ModelView;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hellang.Middleware.ProblemDetails;

namespace Emporos.API.Auth
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private IConfigurationSection _appsettingsConfigurationSection;
        private AppSettings _appSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //AppSettings
            _appsettingsConfigurationSection = Configuration.GetSection(nameof(AppSettings));
            if (_appsettingsConfigurationSection == null)
                throw new NoNullAllowedException("No appsettings has been found");

            _appSettings = _appsettingsConfigurationSection.Get<AppSettings>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (_appSettings.IsValid())
            {
                services.Configure<AppSettings>(_appsettingsConfigurationSection);

                services.AddControllers(
                    opt =>
                    {
                        //Custom filters, if needed
                        //opt.Filters.Add(typeof(CustomFilterAttribute));
                        opt.Filters.Add(new ProducesAttribute("application/json"));
                    })
                    .AddFluentValidation(s =>
                    {
                        s.RegisterValidatorsFromAssemblyContaining<Startup>();
                        s.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                    });

                services.AddProblemDetails(); // Add the required services

                services.AddApiVersioning(
                        o =>
                        {
                            //o.Conventions.Controller<UserController>().HasApiVersion(1, 0);
                            o.ReportApiVersions = true;
                            o.AssumeDefaultVersionWhenUnspecified = true;
                            o.DefaultApiVersion = new ApiVersion(1, 0);
                            o.ApiVersionReader = new UrlSegmentApiVersionReader();
                        });

                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });

                //SWAGGER
                if (_appSettings.Swagger.Enabled)
                {
                    services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

                    services.AddSwaggerGen(options =>
                    {
                        options.OperationFilter<SwaggerDefaultValues>();
                        options.IncludeXmlComments(XmlCommentsFilePath);
                    });
                }

                //Helathchecks
                services.AddHealthChecks()
                 .AddSqlServer(
                                connectionString: Configuration["ConnectionStrings:DefaultConnection"],
                                healthQuery: "SELECT 1;",
                                name: "SQL",
                                failureStatus: HealthStatus.Degraded,
                                tags: new string[] { "db", "sql", "sqlserver" });

                services.AddHealthChecksUI()
                    .AddInMemoryStorage();

                services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                services.AddTransient<IDomainService, DomainService>();
                services.AddTransient<IUserRepository, UserRepository>();
                services.AddTransient<ITokenRepository, TokenRepository>();
                services.AddTransient<IRoleRepository, RoleRepository>();
                
                //Register Validators
                services.AddTransient<IValidator<AuthenticationRequest>, AuthenticationRequestValidator>();

                //Disable Automatic Model State Validation built-in to ASP.NET Core
                services.Configure<ApiBehaviorOptions>(opt => { opt.SuppressModelStateInvalidFilter = true; });
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseProblemDetails(); // Add the middleware

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //SWAGGER
            if (_appSettings.IsValid())
            {
                if (_appSettings.Swagger.Enabled)
                {
                    app.UseSwagger();
                    app.UseSwaggerUI(options =>
                    {
                        foreach (var description in provider.ApiVersionDescriptions)
                        {
                            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", "Emporos Authentication API " +description.GroupName.ToUpperInvariant());
                            //options.RoutePrefix = string.Empty;
                        }
                    });
                }
            }

            app.UseHealthChecks("/healthcheck", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse //nuget: AspNetCore.HealthChecks.UI.Client
            });

            app.UseHealthChecksUI(options =>
            {
                options.UIPath = "/healthchecks-ui";
                options.ApiPath = "/health-ui-api";
            });
        }

        string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }
    }
}

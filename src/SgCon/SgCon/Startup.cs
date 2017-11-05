using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SgConAPI.EntityFramework;
using SgConAPI.Jwt;
using SgConAPI.Models.Configuration;
using SgConAPI.Modules;
using SgConAPI.Options;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace SgCon
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        private const string SecretKey = "sgcon";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            var dir = Path.GetDirectoryName(GetType().GetTypeInfo().Assembly.Location);
         
            var connectionStringName = "DefaultConnection";
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                connectionStringName = "ProductionConnection";
            }
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Homolog")
            {
                connectionStringName = "HomologConnection";
            }
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Staging")
            {
                connectionStringName = "StagingConnection";
            }
            services.AddDbContextPool<SgConContext>(options => options
                .UseMySql(Configuration.GetConnectionString(connectionStringName))
                .ConfigureWarnings(warnings => warnings.Default(WarningBehavior.Ignore)
                        .Log(CoreEventId.IncludeIgnoredWarning,
                                CoreEventId.PossibleUnintendedCollectionNavigationNullComparisonWarning,
                                CoreEventId.PossibleUnintendedReferenceComparisonWarning)
                        .Throw(RelationalEventId.QueryClientEvaluationWarning)
                )
            );

            // Get options from app settings
            services.AddCors(options =>
            {
                options.AddPolicy("SgConPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // Get options from app settings
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "SGCON API", Version = "v1" });

            //    //Set the comments path for the swagger json and ui.
            //    var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            //    var xmlPath = Path.Combine(basePath, "SgConAPI.xml");
            //    if (File.Exists(xmlPath))
            //    {
            //        //c.IncludeXmlComments(xmlPath);
            //    }
            //});

            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("SgConPolicy"));
            });

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

            // Jwt Facade
            services.AddScoped<JwtFactory>();
            services.AddScoped<JwtCurrentUserFactory>();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<RepositoryModule>();
            containerBuilder.RegisterModule<ServicesModule>();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, JwtFactory jwtFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //DbInitializer.Initialize(context);

            jwtFactory.InitJwt(app, Configuration, _signingKey);

            app.UseMvc();

            //app.UseSwagger();

            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SIT API V1");
            //});
        }
    }
}

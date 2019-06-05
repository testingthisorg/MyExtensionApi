using Assassins.Api.AuthAdapters;
using Assassins.Api.AuthAdapters.Firebase;
using Assassins.Configuration;
using Assassins.DataAccess.Contexts;
using Assassins.DataAccess.Repositories.AaAccounts;
using Assassins.DataAccess.Repositories.AppUsers;
using Assassins.DataAccess.Repositories.Campaigns;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;

namespace Assassins.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(env.ContentRootPath)
                                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
                                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.Configure<AppValueConfig>(optSetup =>
            {
                optSetup.SqlCommandTimeout = Configuration.GetValue<int>("AppValues:SqlOptions:CommandTimeout");
                optSetup.ReportsLocation = Configuration.GetValue<string>("AppValues:Reporting:LocalLocation");
                optSetup.ReportingConnString = Configuration.GetConnectionString("ReportingConnection");

                var locTypeStr = Configuration.GetValue<string>("AppValues:Models:LocationType");
                if (!Enum.TryParse(typeof(FileLocationType), locTypeStr, out object locType))
                    throw new Exception("Model Location Type not a valid value");
                optSetup.ModelLocationType = (FileLocationType)locType;
                optSetup.ModelGlobalLocation = Configuration.GetValue<string>("AppValues:Models:GlobalLocation");
                if (!Directory.Exists(optSetup.ModelGlobalLocation))
                    Directory.CreateDirectory(optSetup.ModelGlobalLocation);
                optSetup.AzureModelConnectionString = Configuration.GetValue<string>("AppValues:Models:AzureConnection");
                optSetup.AzureModelFolderName = Configuration.GetValue<string>("AppValues:Models:AzureFolderName");

                var intLocTypeStr = Configuration.GetValue<string>("AppValues:Models:LocationType");
                if (!Enum.TryParse(typeof(FileLocationType), intLocTypeStr, out object intLocType))
                    throw new Exception("Interface Location Type not a valid value");
                optSetup.InterfaceLocationType = (FileLocationType)intLocType;
                optSetup.InterfaceGlobalLocation = Configuration.GetValue<string>("AppValues:Interfaces:GlobalLocation");
                if (!Directory.Exists(optSetup.InterfaceGlobalLocation))
                    Directory.CreateDirectory(optSetup.InterfaceGlobalLocation);

                optSetup.AzureInterfaceConnectionString = Configuration.GetValue<string>("AppValues:Models:AzureConnection");
                optSetup.AzureInterfaceFolderName = Configuration.GetValue<string>("AppValues:Models:AzureFolderName");

                var graphSourceStr = Configuration.GetValue<string>("AppValues:Graphs:Source");
                if (!Enum.TryParse(typeof(GraphsSource), graphSourceStr, out object graphSrc))
                    throw new Exception("Graph source not a valid value");
                optSetup.GraphsSource = (GraphsSource)graphSrc;
                optSetup.GraphsSourceFileDirectory = Configuration.GetValue<string>("AppValues:Graphs:FileDirectory");
                optSetup.GraphsSourceNumberOfIterationsThroughDirectory = Configuration.GetValue<int>("AppValues:Graphs:NumberOfIterationsThroughDirectory");

                if (!Directory.Exists(optSetup.GraphsSourceFileDirectory))
                    Directory.CreateDirectory(optSetup.GraphsSourceFileDirectory);

            });
            var cmdTimeOut = Configuration.GetValue<int>("AppValues:SqlOptions:CommandTimeout");
            services.AddDbContext<MainContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), sqlOpt => sqlOpt.CommandTimeout(cmdTimeOut));
            });

            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAaAccountRepository, AaAccountRepository>();
            services.AddScoped<ICampaignRepository, CampaignRepository>();
            // =====================Firebase=============================================
            services.AddScoped<IAuthAdapter, Firebase>();
            services
               .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.Authority = "https://securetoken.google.com/ad-assassin";
                   options.TokenValidationParameters = new TokenValidationParameters()
                   {
                       ValidateIssuer = true,
                       ValidIssuer = "https://securetoken.google.com/ad-assassin",
                       ValidateAudience = true,
                       ValidAudience = "ad-assassin",
                       ValidateLifetime = true
                   };

               });
            // =====================Firebase=============================================
            services
                .AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.Error += (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs e) =>
                    {

                    };
                });
            ;

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            UpdateDatabase(app);
            if (env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("CorsPolicy");

            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".dll"] = "application/x-msdownload";
            provider.Mappings[".xml"] = "text/xml";

            //app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions()
            {
                ContentTypeProvider = provider
            });
            //app.UseStaticFiles();
            app.UseDirectoryBrowser();
            app.UseAuthentication();
            app.UseMvc();
        }
        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                      .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<MainContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}

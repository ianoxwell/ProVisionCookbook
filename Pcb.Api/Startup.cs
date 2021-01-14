using Pcb.Configuration;
using Pcb.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;
using Pcb.Security;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Http;
using Pcb.Api.Auth;
using Pcb.Service;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Pcb.Mapping;

namespace Pcb.Api
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


            // Add CPT Configuration
            services.AddPcbConfiguration(Configuration);

            services.AddPcbDatabase(Configuration);

            services.AddCptSecurityServices();

            // Add Pcb Configuration
            services.AddPcbServices();

            // Add mapping services
            services.AddMappingServices();

            // Add Cross-origin resource sharing
            services.AddCors();

            // Add JWT Factory for generating json web tokens.
            // Note: scoped to access config, but could be made singleton if security key was passed in.
            services.AddScoped<IJwtFactory, JwtFactory>();

            // Add Context Accessors so we can inject and access the current logged in user's claims.
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("PcbAppSettings").GetSection("SecuritySettings").GetSection("JwtIssuerOptions").GetValue<string>("Key"));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                };
            });
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });
            services.AddVersionedApiExplorer(Options => Options.GroupNameFormat = "'v'VVV");
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen();
            //    services.AddSwaggerGen(c =>
            //    {
            //        //c.TagActionsBy(api => api.GroupBySwaggerGroupAttribute());

            //        // c.OperationFilter<TagByApiExplorerSettingsOperationFilter>(); // Nicer way of grouping using MS standard attribute, but Swagger ignores classes with this ATM
            //        c.SwaggerDoc("v1", new OpenApiInfo
            //        {
            //            Version = "v1",
            //            Title = "CPT API",
            //            Description = "The api used by the CPT application",
            //        });

            //        // Set the comments path for the Swagger JSON and UI.
            //        //var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            //        //var xmlPath = Path.Combine(basePath, "Iht.Api.xml");
            //        //c.IncludeXmlComments(xmlPath);
            //        c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
            //        {
            //            Description = "JWT Authorisation header using the Bearer scheme. Example: \"Authorisation: Bearer {token}\"",
            //            Type = SecuritySchemeType.ApiKey,
            //            Name = "Authorisation",
            //            In = ParameterLocation.Header
            //        });

            //        c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //        {
            //            {
            //                new OpenApiSecurityScheme
            //                {
            //                    Reference = new OpenApiReference
            //                    {
            //                        Type = ReferenceType.SecurityScheme,
            //                        Id = "basic"
            //                    }
            //                },
            //                new string[] {}
            //            }
            //        });
            //        //c.OperationFilter<AuthorisationHeaderParameterOperationFilter>();
            //    });

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var desc in provider.ApiVersionDescriptions)
                    options.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json",
                        desc.GroupName.ToUpperInvariant());
                options.RoutePrefix = "swagger";
            });

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseSwagger();

            //// Enable middle-ware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CPT API V1");
            //    c.RoutePrefix = "swagger";
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

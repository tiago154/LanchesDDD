using lanches.application;
using lanches.domain.Interfaces.Applications;
using lanches.domain.Interfaces.Repositories;
using lanches.infra;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace lanches.ioc
{
    public class DependecyResolve
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            #region Autentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://localhost:44388",
                        ValidAudience = "https://localhost:44388",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("231qw32e15sa64d5sa6456wqe132wq1e32qw132qew132"))
                    };
                });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            #endregion

            #region Applications
            services.AddScoped<IIngredienteApplication, IngredienteApplication>();
            #endregion

            #region Infra
            services.AddScoped<IIngredienteRepository, IngredienteRepository>();
        
            services.AddSingleton(provider =>
            {
                var MongoConfig = _configApp.MongoDb;
                return new MongoClientSettings
                {
                    MinConnectionPoolSize = MongoConfig.MinConnectionPoolSize,
                    MaxConnectionPoolSize = MongoConfig.MaxConnectionPoolSize,
                    Server = new MongoServerAddress(MongoConfig.Host, MongoConfig.Port),
                    Credential = MongoCredential.CreateCredential(MongoConfig.AuthenticationDatabase, MongoConfig.User, MongoConfig.Password)
                };
            });

            services.AddSingleton<IMongoClient>(provider => new MongoClient(provider.GetService<MongoClientSettings>()));
            services.AddSingleton(provider =>
            {
                var database = provider.GetService<IMongoClient>().GetDatabase(_configApp.MongoDb.AuthenticationDatabase);
                return database;
            });
            #endregion

            #region Repositories
            services.AddScoped<IIngredienteRepository, IngredienteRepository>();
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Ingredientes", new Info
                {
                    Version = "v1",
                    Title = "Ingredientes Request",
                    Description = "Endpoint de ingredientes"
                });

                // Carrega os comentarios XML para o Swagger
                var dir = new DirectoryInfo(AppContext.BaseDirectory);
                foreach (var item in dir.EnumerateFiles("*.xml"))
                    c.IncludeXmlComments(item.FullName);

                // Modifica a exibição das classes
                c.CustomSchemaIds(custom =>
                {
                    if (custom.Name == "IngredienteRequest")
                        return "Ingrediente";
                    if (custom.Name == "IngredienteResponse")
                        return "Ingrediente Retorno";

                    return custom.Name;
                });

                // Customiza o tipo da variavel e o exemplo da mesma
                c.MapType<DateTime>(() => new Schema { Type = "date", Format = "date", Example = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                c.AddSecurityRequirement(security);

                //c.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });
            #endregion
        }

        public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "docs/{documentName}/api.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "Lanches DDD - Docs";
                c.SwaggerEndpoint("/docs/Ingredientes/api.json", "Ingredientes");
                c.RoutePrefix = "docs";
                c.InjectStylesheet("/swagger-ui/custom.css");
            });
        }

        public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
        {
            public void Apply(Operation operation, OperationFilterContext context)
            {
                var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;
                var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is AuthorizeFilter);
                var allowAnonymous = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is IAllowAnonymousFilter);

                if (isAuthorized && !allowAnonymous)
                {
                    if (operation.Parameters == null)
                        operation.Parameters = new List<IParameter>();

                    operation.Parameters.Add(new NonBodyParameter
                    {
                        Name = "Authorization",
                        In = "header",
                        Description = "Token",
                        Required = true,
                        Type = "string"
                    });
                }
            }
        }
    }
}

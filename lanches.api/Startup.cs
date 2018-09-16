using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System.Reflection;
using System.Text;

namespace lanches.api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("LanchesDDD", new Info
                {
                    Version = "v1",
                    Title = "Lanches DDD",
                    Description = "API para gerenciamento de Lanches"
                });

                //Set the comments path for the Swagger JSON and UI.

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(System.AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.CustomSchemaIds(custom =>
                {
                    if (custom.Name == "IngredienteRequest")
                        return "Ingrediente";

                    return custom.Name;
                });

                c.UseReferencedDefinitionsForEnums();
                //c.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseStaticFiles();

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "docs/{documentName}/api.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "Lanches DDD - Docs";
                c.SwaggerEndpoint("/docs/LanchesDDD/api.json", "Lanches DDD");
                c.RoutePrefix = "docs";
                c.InjectStylesheet("/swagger-ui/custom.css");

                var pathIndex = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/swagger-ui/index.html");
                c.IndexStream = () => new StreamReader(pathIndex).BaseStream;

            });

            app.UseCors();
            app.UseMvc();
        }
    }
}

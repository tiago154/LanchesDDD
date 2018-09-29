using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace lanches.ioc
{
    public class DependecyResolve
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            #region Applications

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

                    return custom.Name;
                });

                // Customiza o tipo da variavel e o exemplo da mesma
                c.MapType<DateTime>(() => new Schema { Type = "date", Format = "date", Example = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") });
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
    }
}

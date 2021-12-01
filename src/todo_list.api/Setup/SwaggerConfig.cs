using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace todo_list.api.Setup
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<SwaggerDefaultValues>();


            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
        }

        public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
        {
            readonly IApiVersionDescriptionProvider provider;

            public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

            public void Configure(SwaggerGenOptions options)
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                }
            }

            static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
            {
                var info = new OpenApiInfo()
                {
                    Title = "Todo List",
                    Version = description.ApiVersion.ToString(),
                    Description = "API - CRUD Todo List",
                    Contact = new OpenApiContact() { Name = "Jeferson", Email = "jeferson.smoraes@outlook.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                };

                if (description.IsDeprecated)
                {
                    info.Description += " Esta versão está obsoleta!";
                }

                return info;
            }
        }

        public class SwaggerDefaultValues : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                if (operation.Parameters == null)
                {
                    return;
                }

                foreach (var parameter in operation.Parameters)
                {
                    var description = context.ApiDescription
                        .ParameterDescriptions
                        .First(p => p.Name == parameter.Name);

                    var routeInfo = description.RouteInfo;

                    operation.Deprecated = OpenApiOperation.DeprecatedDefault;

                    if (parameter.Description == null)
                    {
                        parameter.Description = description.ModelMetadata?.Description;
                    }

                    if (routeInfo == null)
                    {
                        continue;
                    }

                    if (parameter.In != ParameterLocation.Path && parameter.Schema.Default == null)
                    {
                        parameter.Schema.Default = new OpenApiString(routeInfo.DefaultValue.ToString());
                    }

                    parameter.Required |= !routeInfo.IsOptional;
                }
            }
        }
    }
}

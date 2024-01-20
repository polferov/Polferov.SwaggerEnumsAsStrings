using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

// ReSharper disable ClassNeverInstantiated.Global

namespace Polferov.SwaggerEnumsAsStrings;

/// <summary>
/// ISchemaFilter for enums to be represented as strings in Swagger UI
/// </summary>
public class EnumsAsStringsFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema? schema, SchemaFilterContext? context)
    {
        if (schema?.Properties is null || context?.Type is null || !context.Type.IsEnum)
            return;

        schema.Enum.Clear();
        schema.Type = "string";
        schema.Format = null;
        foreach (var value in Enum.GetValues(context.Type))
        {
            schema.Enum.Add(new OpenApiString(Enum.GetName(context.Type, value)));
        }
    }
}
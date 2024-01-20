using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

// ReSharper disable ClassNeverInstantiated.Global

namespace Polferov.SwaggerEnumsAsStrings;

/// <summary>
/// ISchemaFilter for enums to be represented as strings in Swagger UI.
///
/// The swagger example may vary depending on the <see cref="EnumsAsStringsFilterOptions"/>.
/// </summary>
public class EnumsAsStringsFilter : ISchemaFilter
{
    private readonly EnumsAsStringsFilterOptions _options;

    /// <summary>
    /// ISchemaFilter for enums to be represented as strings in Swagger UI.
    ///
    /// The swagger example may vary depending on the <see cref="EnumsAsStringsFilterOptions"/>.
    /// </summary>
    public EnumsAsStringsFilter(EnumsAsStringsFilterOptions options)
    {
        _ = options ?? throw new ArgumentNullException(nameof(options));
        if (options.MaxExamples is not null && options.MaxExamples.Value < 1)
            throw new ArgumentOutOfRangeException(nameof(options.MaxExamples), "Must be greater than 0");

        _options = options;
    }

    public void Apply(OpenApiSchema? schema, SchemaFilterContext? context)
    {
        if (schema?.Properties is null || context?.Type is null || !context.Type.IsEnum)
            return;

        schema.Enum.Clear();
        schema.Type = "string";
        schema.Format = null;

        var enumValueNames = Enum.GetNames(context.Type);
        foreach (var enumValueName in enumValueNames)
        {
            schema.Enum.Add(new OpenApiString(enumValueName));
        }

        if (!_options.EnumeratedExample)
            return;

        if (_options.MaxExamples is null || _options.MaxExamples.Value > enumValueNames.Length)
        {
            schema.Example = new OpenApiString(string.Join(" | ", enumValueNames));
            return;
        }

        enumValueNames = enumValueNames.Take(_options.MaxExamples.Value - 1).Concat(["..."]).ToArray();
        schema.Example = new OpenApiString(string.Join(" | ", enumValueNames));
    }
}
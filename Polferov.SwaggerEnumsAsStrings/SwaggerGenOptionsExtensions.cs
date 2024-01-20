using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace Polferov.SwaggerEnumsAsStrings;

public static class SwaggerGenOptionsExtensions
{
    public static SwaggerGenOptions AddEnumsAsStringsFilter(this SwaggerGenOptions options)
    {
        options.SchemaFilter<EnumsAsStringsFilter>();
        return options;
    }
}
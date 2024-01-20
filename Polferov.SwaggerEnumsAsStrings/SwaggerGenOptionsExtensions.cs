using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace Polferov.SwaggerEnumsAsStrings;

public static class SwaggerGenOptionsExtensions
{
    /// <summary>
    /// Registers the <see cref="EnumsAsStringsFilter"/> with SwaggerGen
    /// </summary>
    public static SwaggerGenOptions AddEnumsAsStringsFilter(this SwaggerGenOptions options,
        EnumsAsStringsFilterOptions? filterOptions = null)
    {
        options.SchemaFilter<EnumsAsStringsFilter>(filterOptions ?? new EnumsAsStringsFilterOptions());
        return options;
    }
}
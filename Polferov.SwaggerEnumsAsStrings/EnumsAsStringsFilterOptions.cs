// ReSharper disable UnusedMember.Global

namespace Polferov.SwaggerEnumsAsStrings;

public class EnumsAsStringsFilterOptions
{
    /// <summary>
    /// When true, the example will be a string with possible enum values separated by " | ".
    /// The maximum number of values is specified by <see cref="MaxExamples"/>.
    ///
    /// The default value is false.
    /// </summary>
    public bool EnumeratedExample { get; set; } = false;

    /// <summary>
    /// Determines the maximum number of enum values to be included in the example.
    /// For details, see <see cref="EnumeratedExample"/>.
    /// When null, all values will be included.
    ///
    /// When there are more values than specified by this property, one less value will be shown, and "..." will be appended.
    ///
    /// The default value is 5.
    /// </summary>
    public int? MaxExamples { get; set; } = 5;
}
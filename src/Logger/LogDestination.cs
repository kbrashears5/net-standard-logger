using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Logger
{
    /// <summary>
    /// Destination for where logs get written to
    /// Default: <see cref="LogDestination.Console"/>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LogDestination
    {
        /// <summary>
        /// Output to the console
        /// </summary>
        Console = 0,

        /// <summary>
        /// Output to the Windows EventViewer
        /// </summary>
        EventViewer = 1,

        /// <summary>
        /// Output to a file
        /// </summary>
        File = 2,
    }
}
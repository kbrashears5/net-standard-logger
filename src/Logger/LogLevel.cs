using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Logger
{
    /// <summary>
    /// Log level
    /// Default: <see cref="LogLevel.Information"/>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LogLevel
    {
        /// <summary>
        /// Debug <see cref="LogLevel"/>. Most verbose
        /// Includes all <see cref="LogLevel.Trace"/>, <see cref="LogLevel.Information"/>, <see cref="LogLevel.Warning"/>, <see cref="LogLevel.Error"/> logs
        /// </summary>
        Debug = -2,

        /// <summary>
        /// Trace <see cref="LogLevel"/>. More detailed logs
        /// Includes all <see cref="LogLevel.Information"/>, <see cref="LogLevel.Warning"/>, <see cref="LogLevel.Error"/> logs
        /// </summary>
        Trace = -1,

        /// <summary>
        /// Information <see cref="LogLevel"/>. Information purposes only
        /// Includes all <see cref="LogLevel.Warning"/>, <see cref="LogLevel.Error"/> logs
        /// </summary>
        Information = 0,

        /// <summary>
        /// Warning <see cref="LogLevel"/>. Showing warning logs
        /// Includes all <see cref="LogLevel.Error"/> logs
        /// </summary>
        Warning = 1,

        /// <summary>
        /// Errors <see cref="LogLevel"/>. Errors only
        /// </summary>
        Error = 2,
    };
}
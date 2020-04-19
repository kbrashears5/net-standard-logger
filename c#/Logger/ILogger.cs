using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Logger
{
    /// <summary>
    /// Log level
    /// Default: <see cref="LogLevel.Information"/>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LogLevel
    {
        Debug = -2,
        Trace = -1,
        Information = 0,
        Warning = 1,
        Error = 2,
    };

    /// <summary>
    /// Destination for where logs get written to
    /// Default: <see cref="LogDestination.Console"/>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LogDestination
    {
        Console = 0,
        EventViewer = 1,
        File
    }

    /// <summary>
    /// Interface for a Logger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Change the <see cref="LogLevel"/> for the given implementation of <see cref="ILogger"/>
        /// </summary>
        /// <param name="logLevel"></param>
        void ChangeLogLevel(LogLevel logLevel);

        /// <summary>
        /// Get the log level
        /// </summary>
        /// <returns></returns>
        LogLevel GetLogLevel();

        /// <summary>
        /// Get the log name
        /// </summary>
        /// <returns></returns>
        string GetLogName();

        /// <summary>
        /// Initialize the logging destination
        /// </summary>
        void Initialize();

        /// <summary>
        /// Log <see cref="LogLevel.Error"/> message
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        void LogError(string message,
           int tabs = 0);

        /// <summary>
        /// Log IEnumerable <see cref="LogLevel.Error"/> message
        /// </summary>
        /// <param name="title">Title of the list</param>
        /// <param name="items"><see cref="IEnumerable{string}"/> of to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        void LogError(string title,
            IEnumerable<string> items,
            int tabs = 0);

        /// <summary>
        /// Log <see cref="LogLevel.Information"/> message
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        void LogInformation(string message,
           int tabs = 0);

        /// <summary>
        /// Log IEnumerable <see cref="LogLevel.Information"/> message
        /// </summary>
        /// <param name="title">Title of the list</param>
        /// <param name="items"><see cref="IEnumerable{string}"/> of to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        void LogInformation(string title,
            IEnumerable<string> items,
            int tabs = 0);

        /// <summary>
        /// Log <see cref="LogLevel.Trace"/> message
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        void LogTrace(string message,
           int tabs = 0);

        /// <summary>
        /// Log IEnumerable <see cref="LogLevel.Trace"/> message
        /// </summary>
        /// <param name="title">Title of the list</param>
        /// <param name="items"><see cref="IEnumerable{string}"/> of to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        void LogTrace(string title,
            IEnumerable<string> items,
            int tabs = 0);

        /// <summary>
        /// Log <see cref="LogLevel.Warning"/> message
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        void LogWarning(string message,
           int tabs = 0);

        /// <summary>
        /// Log IEnumerable <see cref="LogLevel.Warning"/> message
        /// </summary>
        /// <param name="title">Title of the list</param>
        /// <param name="items"><see cref="IEnumerable{string}"/> of to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        void LogWarning(string title,
           IEnumerable<string> items,
           int tabs = 0);
    }
}
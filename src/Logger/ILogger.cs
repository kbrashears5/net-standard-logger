using System;
using System.Collections.Generic;

namespace Logger
{
    /// <summary>
    /// Interface for a Logger
    /// </summary>
    public interface ILogger : IDisposable
    {
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
        /// Log <see cref="LogLevel.Debug"/> message
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        void LogDebug(string message,
           int tabs = 0);

        /// <summary>
        /// Log IEnumerable <see cref="LogLevel.Debug"/> message
        /// </summary>
        /// <param name="title">Title of the list</param>
        /// <param name="items">IEnumerable to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        void LogDebug(string title,
            IEnumerable<string> items,
            int tabs = 0);

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
        /// <param name="items">IEnumerable to log</param>
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
        /// <param name="items">IEnumerable to log</param>
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
        /// <param name="items">IEnumerable to log</param>
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
        /// <param name="items">IEnumerable to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        void LogWarning(string title,
           IEnumerable<string> items,
           int tabs = 0);

        /// <summary>
        /// Set the <see cref="LogLevel"/> for the given implementation of <see cref="ILogger"/>
        /// </summary>
        /// <param name="logLevel"></param>
        void SetLogLevel(LogLevel logLevel);
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Logger
{
    /// <summary>
    /// Base implementation of <see cref="ILogger"/>
    /// </summary>
    public abstract class BaseLogger : ILogger
    {
        /// <summary>
        /// Log level
        /// </summary>
        public LogLevel LogLevel { get; private set; }

        /// <summary>
        /// Name of the <see cref="ILogger"/>
        /// </summary>
        private string LogName { get; set; }

        /// <summary>
        /// Length of the longest <see cref="Logger.LogLevel"/>
        /// </summary>
        private int LongestLengthEnumName { get; set; }

        /// <summary>
        /// Create a new instance of <see cref="BaseLogger"/>
        /// </summary>
        /// <param name="logLevel">LogLevel - Defaults to <see cref="LogLevel.Information"/></param>
        /// <param name="logName">Name of the log</param>
        /// <exception cref="ArgumentNullException"></exception>
        public BaseLogger(LogLevel logLevel,
            string logName)
        {
            this.LogName = string.IsNullOrWhiteSpace(logName) ? throw new ArgumentNullException(nameof(logName)) : logName;

            this.LogLevel = logLevel;

            this.LongestLengthEnumName = this.GetLongestEnumNameLength();
        }

        #region IDisposable

        /// <summary>
        /// Disposed
        /// </summary>
        private bool Disposed { get; set; } = false;

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {
                    this.LogLevel = Logger.LogLevel.Off;

                    this.LogName = string.Empty;

                    this.LongestLengthEnumName = 0;
                }

                this.Disposed = true;
            }
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~BaseLogger() => this.Dispose(disposing: false);

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            this.Dispose(disposing: true);

            GC.SuppressFinalize(this);
        }

        #endregion IDisposable

        /// <summary>
        /// Change the <see cref="Logger.LogLevel"/> for the given implementation of <see cref="ILogger"/>
        /// </summary>
        /// <param name="logLevel"></param>
        public void SetLogLevel(LogLevel logLevel)
        {
            this.LogLevel = logLevel;
        }

        /// <summary>
        /// Create the log message
        /// </summary>
        /// <param name="logLevel"><see cref="Logger.LogLevel"/> to log</param>
        /// <param name="message">The message to log</param>
        /// <param name="logMessageEmpty">Is the log message empty or not</param>
        /// <param name="tabs">How many tabs to push the log by</param>
        /// <returns></returns>
        protected string CreateLogMessage(LogLevel logLevel,
            string message,
            out bool logMessageEmpty,
            int tabs = 0)
        {
            var logMessage = string.Empty;

            if (logLevel == Logger.LogLevel.Off)
            {
                logMessageEmpty = true;

                return string.Empty;
            }
            else if (logLevel >= this.LogLevel)
            {
                var dateTime = DateTime.Now;

                var tabsString = new string('\t', tabs);

                logMessage = string.Format("{0}\t{1}\t{2}{3}",
                    dateTime,
                    this.CreateLogLevelString(logLevel),
                    tabsString,
                    message);
            }

            logMessageEmpty = string.IsNullOrWhiteSpace(logMessage);

            return logMessage;
        }

        /// <summary>
        /// Creates the <see cref="Logger.LogLevel"/> string
        /// </summary>
        /// <param name="logLevel"><see cref="Logger.LogLevel"/> to log</param>
        /// <returns></returns>
        private string CreateLogLevelString(LogLevel logLevel)
        {
            var enumLength = Enum.GetName(enumType: typeof(LogLevel),
                value: logLevel).Length;

            var length = this.LongestLengthEnumName - enumLength;

            var logLevelString = string.Format("[{0}]",
                logLevel.ToString());

            for (var i = 0; i < length; i++)
            {
                logLevelString += " ";
            }

            return logLevelString;
        }

        /// <summary>
        /// Gets the length of the longest name in <see cref="Logger.LogLevel"/> for spacing purposes
        /// </summary>
        /// <returns></returns>
        private int GetLongestEnumNameLength()
        {
            var enumNames = Enum.GetNames(typeof(LogLevel));

            var length = 0;

            foreach (var enumName in enumNames)
            {
                if (enumName.Length > length)
                    length = enumName.Length;
            }

            return length;
        }

        /// <summary>
        /// Get the log level
        /// </summary>
        /// <returns></returns>
        public LogLevel GetLogLevel()
        {
            return this.LogLevel;
        }

        /// <summary>
        /// Get the log name
        /// </summary>
        /// <returns></returns>
        public string GetLogName()
        {
            return this.LogName;
        }

        /// <summary>
        /// Initialize the logging destination
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Log <see cref="LogLevel.Debug"/> message
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        public void LogDebug(string message,
            int tabs = 0)
        {
            this.Output(logLevel: LogLevel.Error,
              message: message,
              tabs: tabs);
        }

        /// <summary>
        /// Log IEnumerable <see cref="LogLevel.Debug"/> message
        /// </summary>
        /// <param name="title">Title of the list</param>
        /// <param name="items">=IEnumerable to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        public void LogDebug(string title,
            IEnumerable<string> items,
            int tabs = 0)
        {
            this.OutputList(logLevel: LogLevel.Error,
                title: title,
                items: items,
                tabs: tabs);
        }

        /// <summary>
        /// Log <see cref="LogLevel.Error"/> message
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        public void LogError(string message,
            int tabs = 0)
        {
            this.Output(logLevel: LogLevel.Error,
                message: message,
                tabs: tabs);
        }

        /// <summary>
        /// Log IEnumerable <see cref="LogLevel.Error"/> message
        /// </summary>
        /// <param name="title">Title of the list</param>
        /// <param name="items">=IEnumerable to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        public void LogError(string title,
            IEnumerable<string> items,
            int tabs = 0)
        {
            this.OutputList(logLevel: LogLevel.Error,
                title: title,
                items: items,
                tabs: tabs);
        }

        /// <summary>
        /// Log <see cref="LogLevel.Information"/> message
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        public void LogInformation(string message,
           int tabs = 0)
        {
            this.Output(logLevel: LogLevel.Information,
                message: message,
                tabs: tabs);
        }

        /// <summary>
        /// Log IEnumerable <see cref="LogLevel.Information"/> message
        /// </summary>
        /// <param name="title">Title of the list</param>
        /// <param name="items">IEnumerable to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        public void LogInformation(string title,
            IEnumerable<string> items,
            int tabs = 0)
        {
            this.OutputList(logLevel: LogLevel.Information,
                title: title,
                items: items,
                tabs: tabs);
        }

        /// <summary>
        /// Log <see cref="LogLevel.Trace"/> message
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        public void LogTrace(string message,
            int tabs = 0)
        {
            this.Output(logLevel: LogLevel.Trace,
                message: message,
                tabs: tabs);
        }

        /// <summary>
        /// Log IEnumerable <see cref="LogLevel.Trace"/> message
        /// </summary>
        /// <param name="title">Title of the list</param>
        /// <param name="items">IEnumerable to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        public void LogTrace(string title,
            IEnumerable<string> items,
            int tabs = 0)
        {
            this.OutputList(logLevel: LogLevel.Trace,
                title: title,
                items: items,
                tabs: tabs);
        }

        /// <summary>
        /// Log <see cref="LogLevel.Warning"/> message
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        public void LogWarning(string message,
            int tabs = 0)
        {
            this.Output(logLevel: LogLevel.Warning,
                message: message,
                tabs: tabs);
        }

        /// <summary>
        /// Log IEnumerable <see cref="LogLevel.Warning"/> message
        /// </summary>
        /// <param name="title">Title of the list</param>
        /// <param name="items">IEnumerable to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        public void LogWarning(string title,
            IEnumerable<string> items,
            int tabs = 0)
        {
            this.OutputList(logLevel: LogLevel.Warning,
                title: title,
                items: items,
                tabs: tabs);
        }

        /// <summary>
        /// Output to log
        /// </summary>
        /// <param name="logLevel">LogLevel</param>
        /// <param name="message">Message to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        protected abstract void Output(LogLevel logLevel,
            string message,
            int tabs = 0);

        /// <summary>
        /// Output IEnumerable
        /// </summary>
        /// <param name="logLevel">LogLevel</param>
        /// <param name="title">Title of the list</param>
        /// <param name="items">IEnumerable to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        /// <exception cref="ArgumentNullException"></exception>
        private void OutputList(LogLevel logLevel,
            string title,
            IEnumerable<string> items,
            int tabs = 0)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentNullException(nameof(title));
            if (items == null) throw new ArgumentNullException(nameof(items));

            var message = string.Join("\n",
                items.ToList());

            var finalMessage = string.Join("\n",
                title,
                message);

            this.Output(logLevel: logLevel,
                message: finalMessage,
                tabs: tabs);
        }
    }
}
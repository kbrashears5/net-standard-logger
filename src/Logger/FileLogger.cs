using System;
using System.IO;

namespace Logger
{
    /// <summary>
    /// Implementation of <see cref="ILogger"/> to write to <see cref="LogDestination.File"/>
    /// </summary>
    public class FileLogger : BaseLogger
    {
        /// <summary>
        /// Path to the log file
        /// </summary>
        private string LogFilePath { get; set; }

        /// <summary>
        /// Create a new instance of <see cref="FileLogger"/>
        /// </summary>
        /// <param name="logLevel">LogLevel - Defaults to <see cref="LogLevel.Information"/></param>
        /// <param name="logFilePath">File path to the log file</param>
        /// <param name="logName">Log name</param>
        /// <exception cref="ArgumentNullException"></exception>
        public FileLogger(LogLevel logLevel,
            string logFilePath,
            string logName) : base(logLevel: logLevel, logName: logName)
        {
            this.LogFilePath = string.IsNullOrWhiteSpace(logFilePath) ? throw new ArgumentNullException(nameof(logFilePath)) : logFilePath;
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
        protected override void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                base.Dispose(disposing: disposing);

                if (disposing)
                    this.LogFilePath = string.Empty;

                this.Disposed = true;
            }
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~FileLogger() => this.Dispose(disposing: false);

        #endregion IDisposable

        /// <summary>
        /// Initialize the <see cref="LogDestination.File"/>
        /// </summary>
        public override void Initialize()
        {
            lock (this.LogFilePath)
            {
                if (!File.Exists(path: this.LogFilePath))
                    _ = File.Create(path: this.LogFilePath);
            }
        }

        /// <summary>
        /// Output to <see cref="LogDestination.File"/>
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="tabs"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected override void Output(LogLevel logLevel,
            string message,
            int tabs = 0)
        {
            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));

            // TODO figure out how to create new file when it gets too large and archive the current one

            var logMessage = this.CreateLogMessage(logLevel: logLevel,
                message: message,
                logMessageEmpty: out var logMessageEmpty,
                tabs: tabs);

            if (logMessageEmpty)
                return;

            // TODO how does this affect performance, should we need it anyways, throws an exception without it
            lock (this.LogFilePath)
            {
                using (var streamWriter = new StreamWriter(path: this.LogFilePath, append: true))
                {
                    _ = streamWriter.WriteLineAsync(value: logMessage);

                    streamWriter.Close();
                }
            }
        }
    }
}
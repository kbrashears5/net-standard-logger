using System;

namespace Logger
{
    /// <summary>
    /// Implementation of <see cref="ILogger"/> to write to <see cref="LogDestination.Console"/>
    /// </summary>
    public class ConsoleLogger : BaseLogger
    {
        /// <summary>
        /// Create a new instance of <see cref="ConsoleLogger"/>
        /// </summary>
        /// <param name="logLevel">LogLevel - Defaults to <see cref="LogLevel.Information"/></param>
        /// <param name="logName">Log name</param>
        public ConsoleLogger(LogLevel logLevel,
            string logName) : base(logLevel: logLevel, logName: logName)
        {
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
                {
                }

                this.Disposed = true;
            }
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~ConsoleLogger() => this.Dispose(disposing: false);

        #endregion IDisposable

        /// <summary>
        /// Initialize the <see cref="LogDestination.Console"/>
        /// </summary>
        public override void Initialize()
        {
            return;
        }

        /// <summary>
        /// Output to <see cref="LogDestination.Console"/>
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

            var logMessage = this.CreateLogMessage(logLevel: logLevel,
                message: message,
                logMessageEmpty: out var logMessageEmpty,
                tabs: tabs);

            if (logMessageEmpty)
                return;

            Console.WriteLine(logMessage);
        }
    }
}
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
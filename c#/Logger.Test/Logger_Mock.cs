namespace Logger.Test
{
    /// <summary>
    /// Mock implementation of <see cref="ILogger"/>
    /// </summary>
    public class Logger_Mock : BaseLogger
    {
        /// <summary>
        /// Create a new instance of <see cref="Logger_Mock"/>
        /// </summary>
        /// <param name="logLevel">LogLevel - Defaults to <see cref="LogLevel.Information"/></param>
        /// <param name="logFilePath">File path to the log file</param>
        /// <param name="logName">Log name</param>
        public Logger_Mock(LogLevel logLevel,
            string logName) : base(logLevel: logLevel, logName: logName)
        {
        }

        /// <summary>
        /// Initialize
        /// </summary>
        public override void Initialize()
        {
            return;
        }

        /// <summary>
        /// Output
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="tabs"></param>
        protected override void Output(LogLevel logLevel,
            string message,
            int tabs = 0)
        {
            return;
        }
    }
}
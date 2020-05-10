namespace Logger.Test
{
    /// <summary>
    /// Test Values for the <see cref="Logger.Test"/> namespace
    /// </summary>
    public static class TestValues
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

        public static LogLevel LogLevel { get; } = LogLevel.Debug;

        public static string LogName { get; } = nameof(LogName);

        public static ILogger ConsoleLogger { get; } = new ConsoleLogger(logLevel: LogLevel,
            logName: LogName);

        public static string EventLogSource { get; } = "Application";

        public static ILogger EventViewerLogger { get; } = new EventViewerLogger(logLevel: LogLevel,
            eventLogSource: EventLogSource,
            logName: LogName);

        public static ILogger Logger_Null { get; }

        public static ILogger Logger_Mock { get; } = new Logger_Mock(logLevel: LogLevel,
            logName: LogName);

        public static string Title { get; } = nameof(Title);

        public static string LogFilePath { get; } = @"C:\Windows\system32\drivers\etc\hosts";

        public static ILogger FileLogger { get; } = new FileLogger(logLevel: LogLevel,
            logFilePath: LogFilePath,
            logName: LogName);

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
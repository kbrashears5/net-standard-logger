using System.Collections.Generic;

namespace Logger.Test
{
    public static class TestValues
    {
        public static LogLevel LogLevel { get; } = LogLevel.Trace;

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
    }
}
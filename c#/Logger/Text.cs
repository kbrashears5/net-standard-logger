using System;

namespace Logger
{
    public static class Text
    {
        public static string Name { get; } = nameof(Logger);

        public static string EventLogAlreadyExists { get; } = "Event log already exists";

        public static int MaxEventLogSize { get; } = 32000;
    }
}
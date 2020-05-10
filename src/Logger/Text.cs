namespace Logger
{
    /// <summary>
    /// Static text for the <see cref="Logger"/> namespace
    /// </summary>
    public static class Text
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

        public static string Name { get; } = nameof(Logger);

        public static string EventLogAlreadyExists { get; } = "Event log already exists";

        public static int MaxEventLogSize { get; } = 32000;

        public static string NotRunningAsAdmin { get; } = "Not running as admin";

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;

namespace Logger
{
    /// <summary>
    /// Implementation of <see cref="ILogger"/> to write to <see cref="LogDestination.EventViewer"/>
    /// </summary>
    public class EventViewerLogger : BaseLogger
    {
        /// <summary>
        /// Source of the event log
        /// </summary>
        private string EventLogSource { get; set; }

        /// <summary>
        /// Create a new instance of <see cref="EventViewerLogger"/>
        /// </summary>
        /// <param name="logLevel">LogLevel - Defaults to <see cref="LogLevel.Information"/></param>
        /// <param name="eventLogSource">Event log source name</param>
        /// <param name="logName">Log name</param>
        /// <exception cref="ArgumentNullException"></exception>
        public EventViewerLogger(LogLevel logLevel,
            string eventLogSource,
            string logName) : base(logLevel: logLevel, logName: logName)
        {
            this.EventLogSource = string.IsNullOrWhiteSpace(eventLogSource) ? throw new ArgumentNullException(nameof(eventLogSource)) : eventLogSource;
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
                    this.EventLogSource = string.Empty;

                this.Disposed = true;
            }
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~EventViewerLogger() => this.Dispose(disposing: false);

        #endregion IDisposable

        /// <summary>
        /// Initialize the <see cref="LogDestination.EventViewer"/>
        /// </summary>
        public override void Initialize()
        {
            lock (this.EventLogSource)
            {
                try
                {
                    var logName = this.GetLogName();

                    EventLog.CreateEventSource(source: this.EventLogSource,
                        logName: logName);
                }
                // swallow the "already exists" exception
                catch (ArgumentException)
                {
                    this.LogWarning(Text.EventLogAlreadyExists);
                }
                // catch the not running as admin exception
                catch (SecurityException)
                {
                    throw new NotRunningAsAdminException();
                }
                // catch any other exception
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Output to <see cref="LogDestination.EventViewer"/>
        /// </summary>
        /// <param name="logLevel">LogLevel</param>
        /// <param name="message">Message to log</param>
        /// <param name="tabs">Number of tabs to offset</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected override void Output(LogLevel logLevel,
            string message,
            int tabs = 0)
        {
            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));

            _ = this.CreateLogMessage(logLevel: logLevel,
                message: message,
                logMessageEmpty: out var logMessageEmpty,
                tabs: tabs);

            if (logMessageEmpty)
                return;

            EventLogEntryType eventLogLevel;

            switch (logLevel)
            {
                case LogLevel.Warning:
                    eventLogLevel = EventLogEntryType.Warning;
                    break;

                case LogLevel.Error:
                    eventLogLevel = EventLogEntryType.Error;
                    break;

                default:
                    eventLogLevel = EventLogEntryType.Information;
                    break;
            }

            if (message.Length > Text.MaxEventLogSize)
            {
                var logMessages = this.SplitMessage(message: message,
                    chunkSize: Text.MaxEventLogSize);

                foreach (var logMessage in logMessages)
                {
                    EventLog.WriteEntry(source: this.EventLogSource,
                        message: logMessage,
                        type: eventLogLevel);
                }
            }
            else
            {
                EventLog.WriteEntry(source: this.EventLogSource,
                    message: message,
                    type: eventLogLevel);
            }
        }

        /// <summary>
        /// Splits messages into smaller ones to be able to fit in an event viewer log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="chunkSize"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        private IEnumerable<string> SplitMessage(string message,
            int chunkSize)
        {
            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));
            if (chunkSize == 0) throw new ArgumentException(nameof(chunkSize));

            var count = message.Length / chunkSize;

            return Enumerable.Range(start: 0, count: count)
                .Select(i => message.Substring(i * chunkSize, chunkSize));
        }
    }
}
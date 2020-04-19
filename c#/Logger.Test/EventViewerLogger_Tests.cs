using Common.Test;
using System;
using Xunit;

namespace Logger.Test
{
    /// <summary>
    /// Test <see cref="EventViewerLogger"/>
    /// </summary>
    public class EventViewerLogger_Tests
    {
        #region Constructor

        /// <summary>
        /// Test that constructor is created successfully
        /// </summary>
        [Fact]
        public void Constructor()
        {
            var logger = new EventViewerLogger(logLevel: LogLevel.Information,
                eventLogSource: TestValues.EventLogSource,
                logName: TestValues.LogName);

            Assert.NotNull(logger);
        }

        /// <summary>
        /// Test that constructor throws for null event log source
        /// </summary>
        [Fact]
        public void Constructor_Null_EventLogSource()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new EventViewerLogger(logLevel: TestValues.LogLevel,
                eventLogSource: Common.Test.TestValues.EmptyString,
                logName: TestValues.LogName));

            TestHelper.AssertEqualArgumentNullException(ex,
                "eventLogSource");
        }

        /// <summary>
        /// Test that constructor throws for null log name
        /// </summary>
        [Fact]
        public void Constructor_Null_LogName()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new EventViewerLogger(logLevel: TestValues.LogLevel,
                eventLogSource: TestValues.EventLogSource,
                logName: Common.Test.TestValues.EmptyString));

            TestHelper.AssertEqualArgumentNullException(ex,
                "logName");
        }

        #endregion Constructor

        #region GetLogName

        /// <summary>
        /// Test that GetLogName returns correct name
        /// </summary>
        [Fact]
        public void GetLogName()
        {
            var logger = new EventViewerLogger(logLevel: LogLevel.Information,
                eventLogSource: TestValues.EventLogSource,
                logName: TestValues.LogName);

            var logName = logger.GetLogName();

            Assert.Equal(TestValues.LogName,
                logName);
        }

        #endregion GetLogName

        #region ChangeLogLevel

        /// <summary>
        /// Test that ChangeLogLevel changes <see cref="LogLevel"/>
        /// </summary>
        [Fact]
        public void ChangeLogLevel()
        {
            var logger = new EventViewerLogger(logLevel: LogLevel.Information,
                eventLogSource: TestValues.EventLogSource,
                logName: TestValues.LogName);

            logger.ChangeLogLevel(logLevel: LogLevel.Trace);

            Assert.Equal(LogLevel.Trace,
                logger.LogLevel);
        }

        #endregion ChangeLogLevel

        #region LogError

        /// <summary>
        /// Test that Output function throws for null title for <see cref="LogLevel.Error"/> logs
        /// </summary>
        [Fact]
        public void ErrorList_Null_Title()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.EventViewerLogger.LogError(title: Common.Test.TestValues.EmptyString,
                items: Common.Test.TestValues.NullStringList));

            TestHelper.AssertEqualArgumentNullException(ex,
                "title");
        }

        /// <summary>
        /// Test that Output function throws for null items for <see cref="LogLevel.Error"/> logs
        /// </summary>
        [Fact]
        public void ErrorList_Null_List()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.EventViewerLogger.LogError(title: TestValues.Title,
                items: Common.Test.TestValues.NullStringList));

            TestHelper.AssertEqualArgumentNullException(ex,
                "items");
        }

        #endregion LogError

        #region LogInformation

        /// <summary>
        /// Test that Output function throws for null title for <see cref="LogLevel.Information"/> logs
        /// </summary>
        [Fact]
        public void InformationList_Null_Title()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.EventViewerLogger.LogInformation(title: Common.Test.TestValues.EmptyString,
                items: Common.Test.TestValues.NullStringList));

            TestHelper.AssertEqualArgumentNullException(ex,
                "title");
        }

        /// <summary>
        /// Test that Output function throws for null items for <see cref="LogLevel.Information"/> logs
        /// </summary>
        [Fact]
        public void InformationList_Null_List()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.EventViewerLogger.LogInformation(title: TestValues.Title,
                items: Common.Test.TestValues.NullStringList));

            TestHelper.AssertEqualArgumentNullException(ex,
                "items");
        }

        #endregion LogInformation

        #region LogTrace

        /// <summary>
        /// Test that Output function throws for null title for <see cref="LogLevel.Trace"/> logs
        /// </summary>
        [Fact]
        public void TraceList_Null_Title()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.EventViewerLogger.LogTrace(title: Common.Test.TestValues.EmptyString,
                items: Common.Test.TestValues.NullStringList));

            TestHelper.AssertEqualArgumentNullException(ex,
                "title");
        }

        /// <summary>
        /// Test that Output function throws for null items for <see cref="LogLevel.Trace"/> logs
        /// </summary>
        [Fact]
        public void TraceList_Null_List()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.EventViewerLogger.LogTrace(title: TestValues.Title,
                items: Common.Test.TestValues.NullStringList));

            TestHelper.AssertEqualArgumentNullException(ex,
                "items");
        }

        #endregion LogTrace

        #region LogWarning

        /// <summary>
        /// Test that Output function throws for null title for <see cref="LogLevel.Warning"/> logs
        /// </summary>
        [Fact]
        public void WarningList_Null_Title()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.EventViewerLogger.LogWarning(title: Common.Test.TestValues.EmptyString,
                items: Common.Test.TestValues.NullStringList));

            TestHelper.AssertEqualArgumentNullException(ex,
                "title");
        }

        /// <summary>
        /// Test that Output function throws for null items for <see cref="LogLevel.Warning"/> logs
        /// </summary>
        [Fact]
        public void WarningList_Null_List()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.EventViewerLogger.LogWarning(title: TestValues.Title,
                items: Common.Test.TestValues.NullStringList));

            TestHelper.AssertEqualArgumentNullException(ex,
                "items");
        }

        #endregion LogWarning
    }
}
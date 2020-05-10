using NetStandardTestHelper.Xunit;
using System;
using Xunit;

namespace Logger.Test
{
    /// <summary>
    /// Test <see cref="ConsoleLogger"/>
    /// </summary>
    public class ConsoleLogger_Tests
    {
        #region Constructor

        /// <summary>
        /// Test that constructor is created successfully
        /// </summary>
        [Fact]
        public void Constructor()
        {
            var logger = new ConsoleLogger(logLevel: LogLevel.Information,
                logName: TestValues.LogName);

            Assert.NotNull(logger);
        }

        /// <summary>
        /// Test that constructor throws for null log name
        /// </summary>
        [Fact]
        public void Constructor_Null_LogName()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new ConsoleLogger(logLevel: TestValues.LogLevel,
                logName: NetStandardTestHelper.TestValues.StringEmpty)); ;

            TestHelper.AssertArgumentNullException(ex,
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
            var logger = new ConsoleLogger(logLevel: LogLevel.Information,
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
            var logger = new ConsoleLogger(logLevel: LogLevel.Information,
                logName: TestValues.LogName);

            logger.SetLogLevel(logLevel: LogLevel.Trace);

            Assert.Equal(LogLevel.Trace,
                logger.LogLevel);
        }

        #endregion ChangeLogLevel

        #region LogError

        /// <summary>
        /// Test that Output function throws for null message for <see cref="LogLevel.Error"/> logs
        /// </summary>
        [Fact]
        public void Error_Null_Message()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.ConsoleLogger.LogError(message: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "message");
        }

        /// <summary>
        /// Test that Output function throws for null title for <see cref="LogLevel.Error"/> logs
        /// </summary>
        [Fact]
        public void ErrorList_Null_Title()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.ConsoleLogger.LogError(title: NetStandardTestHelper.TestValues.StringEmpty,
                items: NetStandardTestHelper.TestValues.IEnumerableStringNull));

            TestHelper.AssertArgumentNullException(ex,
                "title");
        }

        /// <summary>
        /// Test that Output function throws for null items for <see cref="LogLevel.Error"/> logs
        /// </summary>
        [Fact]
        public void ErrorList_Null_List()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.ConsoleLogger.LogError(title: TestValues.Title,
                items: NetStandardTestHelper.TestValues.IEnumerableStringNull));

            TestHelper.AssertArgumentNullException(ex,
                "items");
        }

        #endregion LogError

        #region LogInformation

        /// <summary>
        /// Test that Output function throws for null message for <see cref="LogLevel.Information"/> logs
        /// </summary>
        [Fact]
        public void Information_Null_Message()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.ConsoleLogger.LogInformation(message: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "message");
        }

        /// <summary>
        /// Test that Output function throws for null title for <see cref="LogLevel.Information"/> logs
        /// </summary>
        [Fact]
        public void InformationList_Null_Title()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.ConsoleLogger.LogInformation(title: NetStandardTestHelper.TestValues.StringEmpty,
                items: NetStandardTestHelper.TestValues.IEnumerableStringNull));

            TestHelper.AssertArgumentNullException(ex,
                "title");
        }

        /// <summary>
        /// Test that Output function throws for null items for <see cref="LogLevel.Information"/> logs
        /// </summary>
        [Fact]
        public void InformationList_Null_List()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.ConsoleLogger.LogInformation(title: TestValues.Title,
                items: NetStandardTestHelper.TestValues.IEnumerableStringNull));

            TestHelper.AssertArgumentNullException(ex,
                "items");
        }

        #endregion LogInformation

        #region LogTrace

        /// <summary>
        /// Test that Output function throws for null message for <see cref="LogLevel.Trace"/> logs
        /// </summary>
        [Fact]
        public void Trace_Null_Message()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.ConsoleLogger.LogTrace(message: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "message");
        }

        /// <summary>
        /// Test that Output function throws for null title for <see cref="LogLevel.Trace"/> logs
        /// </summary>
        [Fact]
        public void TraceList_Null_Title()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.ConsoleLogger.LogTrace(title: NetStandardTestHelper.TestValues.StringEmpty,
                items: NetStandardTestHelper.TestValues.IEnumerableStringNull));

            TestHelper.AssertArgumentNullException(ex,
                "title");
        }

        /// <summary>
        /// Test that Output function throws for null items for <see cref="LogLevel.Trace"/> logs
        /// </summary>
        [Fact]
        public void TraceList_Null_List()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.ConsoleLogger.LogTrace(title: TestValues.Title,
                items: NetStandardTestHelper.TestValues.IEnumerableStringNull));

            TestHelper.AssertArgumentNullException(ex,
                "items");
        }

        #endregion LogTrace

        #region LogWarning

        /// <summary>
        /// Test that Output function throws for null message for <see cref="LogLevel.Warning"/> logs
        /// </summary>
        [Fact]
        public void Warning_Null_Message()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.ConsoleLogger.LogWarning(message: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "message");
        }

        /// <summary>
        /// Test that Output function throws for null title for <see cref="LogLevel.Warning"/> logs
        /// </summary>
        [Fact]
        public void WarningList_Null_Title()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.ConsoleLogger.LogWarning(title: NetStandardTestHelper.TestValues.StringEmpty,
                items: NetStandardTestHelper.TestValues.IEnumerableStringNull));

            TestHelper.AssertArgumentNullException(ex,
                "title");
        }

        /// <summary>
        /// Test that Output function throws for null items for <see cref="LogLevel.Warning"/> logs
        /// </summary>
        [Fact]
        public void WarningList_Null_List()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.ConsoleLogger.LogWarning(title: TestValues.Title,
                items: NetStandardTestHelper.TestValues.IEnumerableStringNull));

            TestHelper.AssertArgumentNullException(ex,
                "items");
        }

        #endregion LogWarning
    }
}
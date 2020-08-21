using NetStandardTestHelper.Xunit;
using System;
using Xunit;

namespace Logger.Test
{
    /// <summary>
    /// Test <see cref="FileLogger"/>
    /// </summary>
    public class FileLogger_Tests
    {
        #region Constructor

        /// <summary>
        /// Test that constructor is created successfully
        /// </summary>
        [Fact]
        public void Constructor()
        {
            var logger = new FileLogger(logLevel: LogLevel.Information,
                logFilePath: TestValues.LogFilePath,
                logName: TestValues.LogName);

            Assert.NotNull(logger);
        }

        /// <summary>
        /// Test that constructor throws for null event log source
        /// </summary>
        [Fact]
        public void Constructor_Null_logFilePath()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new FileLogger(logLevel: TestValues.LogLevel,
                logFilePath: NetStandardTestHelper.TestValues.StringEmpty,
                logName: TestValues.LogName));

            TestHelper.AssertArgumentNullException(ex,
                "logFilePath");
        }

        /// <summary>
        /// Test that constructor throws for null log name
        /// </summary>
        [Fact]
        public void Constructor_Null_LogName()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new FileLogger(logLevel: TestValues.LogLevel,
                logFilePath: TestValues.LogFilePath,
                logName: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "logName");
        }

        #endregion Constructor

        #region IDisposable

        /// <summary>
        /// Test that <see cref="IDisposable"/> is disposed correctly
        /// </summary>
        [Fact]
        public void IDisposable()
        {
            var logger = new FileLogger(logLevel: LogLevel.Information,
                logFilePath: TestValues.LogFilePath,
                logName: TestValues.LogName);

            logger.Dispose();

            Assert.Equal(Logger.LogLevel.Off,
                logger.LogLevel);
        }

        #endregion IDisposable

        #region GetLogName

        /// <summary>
        /// Test that GetLogName returns correct name
        /// </summary>
        [Fact]
        public void GetLogName()
        {
            var logger = new FileLogger(logLevel: LogLevel.Information,
                logFilePath: TestValues.LogFilePath,
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
            var logger = new FileLogger(logLevel: LogLevel.Information,
                logFilePath: TestValues.LogFilePath,
                logName: TestValues.LogName);

            logger.SetLogLevel(logLevel: LogLevel.Trace);

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
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.FileLogger.LogError(title: NetStandardTestHelper.TestValues.StringEmpty,
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
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.FileLogger.LogError(title: TestValues.Title,
                items: NetStandardTestHelper.TestValues.IEnumerableStringNull));

            TestHelper.AssertArgumentNullException(ex,
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
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.FileLogger.LogInformation(title: NetStandardTestHelper.TestValues.StringEmpty,
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
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.FileLogger.LogInformation(title: TestValues.Title,
                items: NetStandardTestHelper.TestValues.IEnumerableStringNull));

            TestHelper.AssertArgumentNullException(ex,
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
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.FileLogger.LogTrace(title: NetStandardTestHelper.TestValues.StringEmpty,
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
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.FileLogger.LogTrace(title: TestValues.Title,
                items: NetStandardTestHelper.TestValues.IEnumerableStringNull));

            TestHelper.AssertArgumentNullException(ex,
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
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.FileLogger.LogWarning(title: NetStandardTestHelper.TestValues.StringEmpty,
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
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.FileLogger.LogWarning(title: TestValues.Title,
                items: NetStandardTestHelper.TestValues.IEnumerableStringNull));

            TestHelper.AssertArgumentNullException(ex,
                "items");
        }

        #endregion LogWarning
    }
}
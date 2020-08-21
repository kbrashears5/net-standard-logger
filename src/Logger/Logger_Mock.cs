namespace Logger
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
        /// <param name="logName">Log name</param>
        public Logger_Mock(LogLevel logLevel,
            string logName) : base(logLevel: logLevel, logName: logName)
        {
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
        protected new virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                base.Dispose(disposing: disposing);

                if (disposing)
                {
                }

                this.Disposed = true;
            }
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~Logger_Mock() => this.Dispose(disposing: false);

        #endregion IDisposable

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
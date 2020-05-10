using System;

namespace Logger
{
    /// <summary>
    /// Not running as admin
    /// </summary>
    public class NotRunningAsAdminException : Exception
    {
        /// <summary>
        /// Create new instance of <see cref="NotRunningAsAdminException"/>
        /// </summary>
        public NotRunningAsAdminException() : base(message: Text.NotRunningAsAdmin)
        {
        }
    }
}
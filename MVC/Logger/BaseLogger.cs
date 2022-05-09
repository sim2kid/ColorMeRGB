using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public abstract class BaseLogger : ILogger
    {
        public virtual void Debug(string message, Guid? user = null, string? exception = null)
        {
            Log(ILogger.LogLevel.Debug, message, user, exception);
        }

        public virtual void Error(string message, string exception, Guid? user = null)
        {
            Log(ILogger.LogLevel.Error, message, user, exception);
        }

        public virtual void Fatal(string message, string exception, Guid? user = null)
        {
            Log(ILogger.LogLevel.Fatal, message, user, exception);
        }

        public virtual void Info(string message, Guid? user = null, string? exception = null)
        {
            Log(ILogger.LogLevel.Info, message, user, exception);
        }

        public virtual void Warning(string message, Guid? user = null, string? exception = null)
        {
            Log(ILogger.LogLevel.Warning, message, user, exception);
        }

        public abstract void Log(ILogger.LogLevel level, string message, Guid? user = null, string? exception = null);
    }
}

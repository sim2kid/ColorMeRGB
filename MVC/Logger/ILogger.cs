using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public interface ILogger
    {
        public enum LogLevel {
            Debug,
            Info,
            Warning,
            Error,
            Fatal
        }
        public void Log(LogLevel level, string message, Guid? user = null, string? exception = null);
        public void Debug(string message, Guid? user = null, string? exception = null);
        public void Info(string message, Guid? user = null, string? exception = null);
        public void Warning(string message, Guid? user = null, string? exception = null);
        public void Error(string message, string exception, Guid? user = null);
        public void Fatal(string message, string exception, Guid? user = null);
    }
}

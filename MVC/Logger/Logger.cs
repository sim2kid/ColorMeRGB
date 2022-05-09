using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Logger : BaseLogger
    { 
        private static Logger _instance;
        public static Logger Instance 
        {
            get {
                if (_instance == null) 
                {
                    _instance = Logger.Default();
                }  
                return _instance;
            }   
        }


        public List<ILogger> Loggers;

        private Logger(List<ILogger> loggers) 
        {
            this.Loggers = loggers;
        }

        private static Logger Default() 
        {
            List<ILogger> loggers = new List<ILogger>();
            loggers.Add(new MSSQLDatabaseLogger());
            return new Logger(loggers);
        }

        

        public override void Log(ILogger.LogLevel level, string message, Guid? user, string? exception)
        {
            foreach (var logger in Loggers) 
            {
                logger.Log(level, message, user, exception);
            }
        }
    }
}

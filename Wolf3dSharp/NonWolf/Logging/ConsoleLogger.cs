using System;
using System.Collections.Generic;
using System.Text;

namespace Wolf3dSharp.NonWolf.Logging
{
    public class ConsoleLogger : AbstractLogger
    {
        public ConsoleLogger(LogLevel logLevel) : base(logLevel) { }

        protected override void LogMessage(string message, LogLevel level)
        {
            if (level > _logLevel)
            {
                switch (level)
                {
                    case LogLevel.Debug:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case LogLevel.Info:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case LogLevel.Warning:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case LogLevel.Error:
                    case LogLevel.Critical:
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                }

                if(level > LogLevel.Error)
                {
                    message = message.ToUpper();
                }

                Console.WriteLine(DateTime.UtcNow.ToString("hh:mm:ss.fff") + ": " + message);
            }
        }
    }
}

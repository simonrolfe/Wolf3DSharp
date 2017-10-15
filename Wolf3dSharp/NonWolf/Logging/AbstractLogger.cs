using System;
using System.Collections.Generic;
using System.Text;

namespace Wolf3dSharp.NonWolf.Logging
{
    public abstract class AbstractLogger
    {
        protected readonly LogLevel _logLevel;
        private const int INDENT_CHARS = 2;

        public AbstractLogger (LogLevel logLevel)
        {
            _logLevel = logLevel;
        }

        public LogLevel LogLevel
        {
            get { return _logLevel; }
        }

        protected abstract void LogMessage(string message, LogLevel level);

        public void LogDebug(string message, int indent = 0)
        {
            if(_logLevel < LogLevel.Info)
            {
                LogMessage(new string(' ', INDENT_CHARS * indent) + message, LogLevel.Debug);
            }
        }

        public void LogInfo(string message, int indent = 0)
        {
            if (_logLevel < LogLevel.Warning)
            {
                LogMessage(new string(' ', INDENT_CHARS * indent) + message, LogLevel.Info);
            }
        }

        public void LogWarning(string message, int indent = 0)
        {
            if(_logLevel < LogLevel.Error)
            {
                LogMessage(new string(' ', INDENT_CHARS * indent) + message, LogLevel.Warning);
            }
        }

        public void LogError(string message, int indent = 0)
        {
            if(_logLevel < LogLevel.Critical)
            {
                LogMessage(new string(' ', INDENT_CHARS * indent) + message, LogLevel.Error);
            }
        }

        public void LogCritical(string message)
        {
            //always log critical, don't allow indents
            LogMessage(message, LogLevel.Critical);
        }


    }
}

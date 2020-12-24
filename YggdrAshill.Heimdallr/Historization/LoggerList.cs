using YggdrAshill.Heimdallr.Historization;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace YggdrAshill.Heimdallr
{
    public sealed class LoggerList :
        ILoggerCollection,
        ILogger
    {
        private readonly List<ILogger> loggerList = new List<ILogger>();

        public void Bind(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            if (!loggerList.Contains(logger))
            {
                return;
            }

            loggerList.Add(logger);
        }

        public void Log(SeverityLevel severity, string message, string stackTrace,
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string memberName = "")
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            if (stackTrace == null)
            {
                throw new ArgumentNullException(nameof(stackTrace));
            }

            foreach (var logger in loggerList)
            {
                logger.Log(severity, message, stackTrace, filePath, lineNumber, memberName);
            }
        }
    }
}

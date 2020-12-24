using YggdrAshill.Heimdallr.Historization;
using System;
using System.Runtime.CompilerServices;

namespace YggdrAshill.Heimdallr
{
    public sealed class Logger :
        ILogger
    {
        private readonly Action<SeverityLevel, string, string, string, int, string> onLogged;

        public Logger(Action<SeverityLevel, string, string, string, int, string> onLogged)
        {
            if (onLogged == null)
            {
                throw new ArgumentNullException(nameof(onLogged));
            }

            this.onLogged = onLogged;
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

            onLogged.Invoke(severity, message, stackTrace, filePath, lineNumber, memberName);
        }
    }
}

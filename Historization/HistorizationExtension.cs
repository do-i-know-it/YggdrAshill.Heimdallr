using YggdrAshill.Heimdallr.Elucidation;
using System;
using System.Threading;
using System.Runtime.CompilerServices;

namespace YggdrAshill.Heimdallr.Historization
{
    public static class HistorizationExtension
    {
        private static void Log(this IIndication<Log> indication, SeverityLevel severity, string message, string stackTrace,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = "")
        {
            var dateTime = DateTime.Now;
            var thread = Thread.CurrentThread.ManagedThreadId;

            var log = new Log(severity, dateTime, message, stackTrace, thread, filePath, lineNumber, memberName);

            indication.Indicate(log);
        }

        public static void Log(this IIndication<Log> indication, SeverityLevel severity, string message,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = "")
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var stackTrace = Environment.StackTrace;

            indication.Log(severity, message, stackTrace, filePath, lineNumber, memberName);
        }

        public static void Log(this IIndication<Log> indication, SeverityLevel severity, Exception exception,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = "")
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            var message = exception.ToString();
            var stackTrace = exception.StackTrace;

            indication.Log(severity, message, stackTrace, filePath, lineNumber, memberName);
        }
    }
}

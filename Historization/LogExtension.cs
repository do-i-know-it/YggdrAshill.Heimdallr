using YggdrAshill.Heimdallr.Elucidation;
using System;
using System.Threading;
using System.Runtime.CompilerServices;

namespace YggdrAshill.Heimdallr.Historization
{
    /// <summary>
    /// Defines extensions for <see cref="Log"/>.
    /// </summary>
    public static class LogExtension
    {
        /// <summary>
        /// Records <see cref="Log"/>.
        /// </summary>
        /// <param name="indication">
        /// <see cref="IIndication{TValue}"/> to record <see cref="Log"/>.
        /// </param>
        /// <param name="level">
        /// <see cref="Log.Severity"/> for <see cref="Log.Level"/>.
        /// </param>
        /// <param name="message">
        /// <see cref="string"/> for <see cref="Log.Message"/>.
        /// </param>
        /// <param name="filePath">
        /// <see cref="string"/> for <see cref="Log.FilePath"/>.
        /// </param>
        /// <param name="lineNumber">
        /// <see cref="int"/> for <see cref="Log.LineNumber"/>.
        /// </param>
        /// <param name="memberName">
        /// <see cref="string"/> for <see cref="Log.MemberName"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="indication"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="message"/> is null.
        /// </exception>
        public static void Record(this IIndication<Log> indication,
            Log.Severity level, string message,
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

            indication.Record(level, message, stackTrace, filePath, lineNumber, memberName);
        }

        /// <summary>
        /// Records <see cref="Log"/>.
        /// </summary>
        /// <param name="indication">
        /// <see cref="IIndication{TValue}"/> to record <see cref="Log"/>.
        /// </param>
        /// <param name="level">
        /// <see cref="Log.Severity"/> for <see cref="Log.Level"/>.
        /// </param>
        /// <param name="exception">
        /// <see cref="Exception"/> for <see cref="Log.Message"/>.
        /// </param>
        /// <param name="filePath">
        /// <see cref="string"/> for <see cref="Log.FilePath"/>.
        /// </param>
        /// <param name="lineNumber">
        /// <see cref="int"/> for <see cref="Log.LineNumber"/>.
        /// </param>
        /// <param name="memberName">
        /// <see cref="string"/> for <see cref="Log.MemberName"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="indication"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="exception"/> is null.
        /// </exception>
        public static void Record(this IIndication<Log> indication,
            Log.Severity level, Exception exception,
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

            indication.Record(level, message, stackTrace, filePath, lineNumber, memberName);
        }

        private static void Record(this IIndication<Log> indication,
            Log.Severity level, string message, string stackTrace,
            string filePath, int lineNumber, string memberName)
        {
            var dateTime = DateTime.Now;
            var thread = Thread.CurrentThread.ManagedThreadId;

            var log = new Log(level, dateTime, message, stackTrace, thread, filePath, lineNumber, memberName);

            indication.Indicate(log);
        }
    }
}

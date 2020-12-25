using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using System;
using System.Threading;
using System.Runtime.CompilerServices;

namespace YggdrAshill.Heimdallr.Historization
{
    public static class HistorizationExtension
    {
        public static void Bind(this ILogger logger, ILoggerCollection collection)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            collection.Bind(logger);
        }

        public static ILoggerCollection Bind(this ILoggerCollection collection, ILogger logger)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            collection.Bind(logger);

            return collection;
        }

        public static void Log(this ILogger logger, SeverityLevel severity, string message,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = "")
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var stackTrace = Environment.StackTrace;

            logger.Log(severity, message, stackTrace, filePath, lineNumber, memberName);
        }

        public static void Log(this ILogger logger, SeverityLevel severity, Exception exception,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = "")
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            var message = exception.ToString();
            var stackTrace = exception.StackTrace;

            logger.Log(severity, message, stackTrace, filePath, lineNumber, memberName);
        }

        public static void Log<TItem>(this ILogger logger, SeverityLevel severity, TItem item, INotation<TItem> notation,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = "")
            where TItem : IItem
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            var note = notation.Notate(item);

            logger.Log(severity, note.Content, filePath, lineNumber, memberName);
        }

        public static void Indicate(this IIndication<Log> indication, SeverityLevel severity, string message, string stackTrace,
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
            if (stackTrace == null)
            {
                throw new ArgumentNullException(nameof(stackTrace));
            }

            var dateTime = DateTime.Now;
            var thread = Thread.CurrentThread.ManagedThreadId;

            var information = new Log(severity, dateTime, message, stackTrace, thread, filePath, lineNumber, memberName);

            indication.Indicate(information);
        }

        public static ILogger ToLogger(this IIndication<Note> indication, INotation<Log> notation)
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return indication.Notated(notation).ToLogger();
        }

        public static ILogger ToLogger(this IIndication<Log> indication)
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return new Logger(indication);
        }
        private sealed class Logger :
            ILogger
        {
            private readonly IIndication<Log> indication;

            public Logger(IIndication<Log> indication)
            {
                this.indication = indication;
            }

            public void Log(SeverityLevel severity, string message, string stackTrace,
                [CallerFilePath] string filePath = "",
                [CallerLineNumber] int lineNumber = 0,
                [CallerMemberName] string memberName = "")
            {
                if (message == null)
                {
                    throw new ArgumentNullException(nameof(message));
                }
                if (stackTrace == null)
                {
                    throw new ArgumentNullException(nameof(stackTrace));
                }

                indication.Indicate(severity, message, stackTrace, filePath, lineNumber, memberName);
            }
        }
    }
}

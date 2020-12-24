using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Historization
{
    public struct Log :
        IItem
    {
        public SeverityLevel Severity { get; }

        public DateTime DateTime { get; }

        public string Message { get; }

        public string StackTrace { get; }

        public int Thread { get; }

        public string FilePath { get; }

        public int LineNumber { get; }

        public string MemberName { get; }

        public Log(SeverityLevel severity, DateTime dateTime, string message, string stackTrace, int thread, string filePath, int lineNumber, string memberName)
        {
            Severity = severity;

            Message = message;

            StackTrace = stackTrace;

            DateTime = dateTime;

            Thread = thread;

            FilePath = filePath;

            LineNumber = lineNumber;

            MemberName = memberName;
        }
    }
}

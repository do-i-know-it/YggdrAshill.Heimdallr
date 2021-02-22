using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Items
{
    public struct Log :
        IItem
    {
        [Flags]
        public enum Severity : byte
        {
            None = 0,
            Trace = 1 << 0,
            Notification = 1 << 1,
            Assertion = 1 << 2,
            Information = 1 << 3,
            Warning = 1 << 4,
            Error = 1 << 5,
            Fatal = 1 << 6,
        }

        public Severity Level { get; }

        public DateTime DateTime { get; }

        public string Message { get; }

        public string StackTrace { get; }

        public int Thread { get; }

        public string FilePath { get; }

        public int LineNumber { get; }

        public string MemberName { get; }

        internal Log(Severity level, DateTime dateTime, string message, string stackTrace, int thread, string filePath, int lineNumber, string memberName)
        {
            Level = level;

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

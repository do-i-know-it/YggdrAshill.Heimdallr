using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Historization
{
    /// <summary>
    /// Implementation of <see cref="IValue"/> to record.
    /// </summary>
    public struct Log :
        IValue
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

        /// <summary>
        /// <see cref="Level"/> of <see cref="Severity"/> for <see cref="Log"/>.
        /// </summary>
        public Severity Level { get; }

        /// <summary>
        /// <see cref="DateTime"/> <see cref="Log"/> has recorded.
        /// </summary>
        public DateTime DateTime { get; }

        /// <summary>
        /// <see cref="Message"/> for <see cref="Log"/>.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// <see cref="StackTrace"/> <see cref="Log"/> has recorded.
        /// </summary>
        public string StackTrace { get; }

        /// <summary>
        /// <see cref="Thread"/> number <see cref="Log"/> has recorded.
        /// </summary>
        public int Thread { get; }

        /// <summary>
        /// <see cref="FilePath"/> <see cref="Log"/> has recorded.
        /// </summary>
        public string FilePath { get; }

        /// <summary>
        /// <see cref="LineNumber"/> <see cref="Log"/> has recorded.
        /// </summary>
        public int LineNumber { get; }

        /// <summary>
        /// <see cref="MemberName"/> <see cref="Log"/> has recorded.
        /// </summary>
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

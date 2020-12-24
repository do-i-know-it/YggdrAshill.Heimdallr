using System;

namespace YggdrAshill.Heimdallr.Historization
{
    [Flags]
    public enum SeverityLevel : byte
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
}

using System.Runtime.CompilerServices;

namespace YggdrAshill.Heimdallr.Historization
{
    public interface ILogger
    {
        void Log(SeverityLevel severity, string message, string stackTrace,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = "");
    }
}

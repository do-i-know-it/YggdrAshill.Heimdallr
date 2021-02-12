using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using YggdrAshill.Heimdallr.Historization;
using System;
using System.Runtime.CompilerServices;

namespace YggdrAshill.Heimdallr
{
    public static class HistorizationExtension
    {
        public static void Log<TItem>(this IIndication<Log> indication, SeverityLevel severity, TItem item, Func<TItem, Note> notation,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = "")
            where TItem : IItem
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            indication.Log(severity, item, new Notation<TItem>(notation), filePath, lineNumber, memberName);
        }
    }
}

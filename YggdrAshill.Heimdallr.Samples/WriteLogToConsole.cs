using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Historization;
using System;

namespace YggdrAshill.Heimdallr.Samples
{
    internal sealed class WriteLogToConsole :
        IIndication<Log>
    {
        public void Indicate(Log value)
        {
            Console.WriteLine($"{value.Level}, {value.Message}, {value.StackTrace}, {value.DateTime}");
            Console.WriteLine();
        }
    }
}

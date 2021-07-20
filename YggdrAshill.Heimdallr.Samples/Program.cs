using YggdrAshill.Heimdallr.Historization;
using System;

namespace YggdrAshill.Heimdallr.Samples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var indication = new WriteLogToConsole();

            while (true)
            {
                Console.WriteLine("Please enter any key to emit signals.");
                Console.WriteLine("Please enter \"q\" to quit this program.");
                Console.Write("Key: ");

                var input = Console.ReadLine();
                if (input == "q")
                {
                    indication.Record(Log.Severity.Fatal, "quit.");
                    return;
                }

                indication.Record(Log.Severity.Information, input);
            }
        }
    }
}

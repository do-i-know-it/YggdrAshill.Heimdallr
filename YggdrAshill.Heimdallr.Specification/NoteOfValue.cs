using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    internal class NoteOfValue :
        INotation<Value>
    {
        private readonly string expected;

        internal NoteOfValue(string expected = "")
        {
            this.expected = expected;
        }

        public Note Notate(Value value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return new Note(expected);
        }
    }
}

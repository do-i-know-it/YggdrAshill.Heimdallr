using YggdrAshill.Heimdallr.Inspection;
using System;

namespace YggdrAshill.Heimdallr.Conversion
{
    public sealed class Note :
        IItem
    {
        public string Content { get; }

        public Note(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            Content = content;
        }
    }
}

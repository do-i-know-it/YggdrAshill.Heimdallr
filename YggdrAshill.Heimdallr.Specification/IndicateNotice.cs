using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    internal class IndicateNotice :
        IIndication<Notice>
    {
        internal bool Indicated { get; private set; }

        public void Indicate(Notice value)
        {
            if (value == null)
            {
                throw new InvalidOperationException(nameof(value));
            }

            Indicated = true;
        }
    }
}

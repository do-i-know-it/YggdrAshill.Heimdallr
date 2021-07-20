using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    internal class NoticeOfValue :
        ICondition<Value>
    {
        private readonly bool expected;

        internal NoticeOfValue(bool expected = false)
        {
            this.expected = expected;
        }

        public bool IsSatisfiedBy(Value value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return expected;
        }
    }
}

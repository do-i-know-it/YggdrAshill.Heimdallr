using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr
{
    public sealed class Condition<TItem> :
        ICondition<TItem>
        where TItem : IInformation
    {
        public static ICondition<TItem> All { get; }
            = new Condition<TItem>(_ =>
            {
                return true;
            });

        public static ICondition<TItem> None { get; }
            = new Condition<TItem>(_ =>
            {
                return false;
            });

        private readonly Func<TItem, bool> onNotified;

        public Condition(Func<TItem, bool> onNotified)
        {
            if (onNotified == null)
            {
                throw new ArgumentNullException(nameof(onNotified));
            }

            this.onNotified = onNotified;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return onNotified.Invoke(item);
        }
    }
}

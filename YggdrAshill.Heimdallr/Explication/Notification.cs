using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr
{
    public sealed class Notification<TItem> :
        INotification<TItem>
        where TItem : IItem
    {
        public static INotification<TItem> All { get; }
            = new Notification<TItem>(_ =>
            {
                return true;
            });

        public static INotification<TItem> None { get; }
            = new Notification<TItem>(_ =>
            {
                return false;
            });

        private readonly Func<TItem, bool> onNotified;

        public Notification(Func<TItem, bool> onNotified)
        {
            if (onNotified == null)
            {
                throw new ArgumentNullException(nameof(onNotified));
            }

            this.onNotified = onNotified;
        }

        public bool Notify(TItem item)
        {
            return onNotified.Invoke(item);
        }
    }
}

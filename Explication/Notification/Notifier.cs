using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Explication
{
    internal sealed class Notifier<TItem> :
        ISubscription<Notice>
        where TItem : IItem
    {
        private readonly ISubscription<TItem> subscription;

        private readonly INotification<TItem> notification;

        internal Notifier(ISubscription<TItem> subscription, INotification<TItem> notification)
        {
            this.subscription = subscription;

            this.notification = notification;
        }

        public IUnsubscription Subscribe(IIndication<Notice> indication)
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return subscription.Subscribe(new Notify<TItem>(indication, notification));
        }
    }
}

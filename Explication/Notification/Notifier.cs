using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Explication
{
    internal sealed class Notifier<TItem> :
        ISubscription<Notice>
        where TItem : IItem
    {
        private readonly ISubscription<TItem> subscription;

        private readonly ICondition<TItem> condition;

        internal Notifier(ISubscription<TItem> subscription, ICondition<TItem> condition)
        {
            this.subscription = subscription;

            this.condition = condition;
        }

        public IUnsubscription Subscribe(IIndication<Notice> indication)
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return subscription.Subscribe(new Notify<TItem>(indication, condition));
        }
    }
}

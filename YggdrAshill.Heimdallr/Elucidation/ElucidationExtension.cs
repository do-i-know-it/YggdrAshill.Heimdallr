using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr
{
    public static class ElucidationExtension
    {
        public static IUnsubscription Subscribe<TItem>(this ISubscription<TItem> subscription, Action<TItem> onIndicated)
            where TItem : IItem
        {
            if (subscription == null)
            {
                throw new ArgumentNullException(nameof(subscription));
            }
            if (onIndicated == null)
            {
                throw new ArgumentNullException(nameof(onIndicated));
            }

            var indication = new Indication<TItem>(onIndicated);

            return subscription.Subscribe(indication);
        }
    }
}

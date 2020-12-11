using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr
{
    public static class ElucidationExtension
    {
        public static IUnsubscription Subscribe<TItem>(this IObservation<TItem> observation, Action<TItem> onIndicated)
            where TItem : IItem
        {
            if (observation == null)
            {
                throw new ArgumentNullException(nameof(observation));
            }
            if (onIndicated == null)
            {
                throw new ArgumentNullException(nameof(onIndicated));
            }

            var indication = new Indication<TItem>(onIndicated);

            return observation.Subscribe(indication);
        }
    }
}

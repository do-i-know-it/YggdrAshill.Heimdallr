using YggdrAshill.Heimdallr.Inspection;
using System;

namespace YggdrAshill.Heimdallr
{
    public static class InspectionExtension
    {
        public static IUnsubscription Subscribe<TItem>(this IPublication<TItem> publication, Action<TItem> onIndicated)
            where TItem : IItem
        {
            if (publication == null)
            {
                throw new ArgumentNullException(nameof(publication));
            }
            if (onIndicated == null)
            {
                throw new ArgumentNullException(nameof(onIndicated));
            }

            var indication = new Indication<TItem>(onIndicated);

            return publication.Subscribe(indication);
        }

        public static IExecution Activate<TItem>(this IObservation<TItem> observation, Action<TItem> onIndicated)
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

            return observation.Activate(indication);
        }
    }
}

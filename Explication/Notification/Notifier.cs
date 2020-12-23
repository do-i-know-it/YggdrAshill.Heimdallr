using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Explication
{
    internal sealed class Notifier<TItem> :
        IObservation<Notice>
        where TItem : IItem
    {
        private readonly IObservation<TItem> observation;

        private readonly INotification<TItem> notification;

        internal Notifier(IObservation<TItem> observation, INotification<TItem> notification)
        {
            this.observation = observation;

            this.notification = notification;
        }

        public IUnsubscription Subscribe(IIndication<Notice> indication)
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return observation.Subscribe(new Notify<TItem>(indication, notification));
        }
    }
}

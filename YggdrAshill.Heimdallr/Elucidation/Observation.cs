using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr
{
    public sealed class Observation<TItem> :
        IObservation<TItem>
        where TItem : IItem
    {
        private readonly Func<IIndication<TItem>, IUnsubscription> onSubscribed;

        #region Constructor

        public Observation(Func<IIndication<TItem>, IUnsubscription> onSubscribed)
        {
            if (onSubscribed == null)
            {
                throw new ArgumentNullException(nameof(onSubscribed));
            }

            this.onSubscribed = onSubscribed;
        }

        public Observation()
        {
            onSubscribed = (_) =>
            {
                return new Unsubscription();
            };
        }

        #endregion

        #region IObservation

        public IUnsubscription Subscribe(IIndication<TItem> indication)
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return onSubscribed.Invoke(indication);
        }

        #endregion
    }
}

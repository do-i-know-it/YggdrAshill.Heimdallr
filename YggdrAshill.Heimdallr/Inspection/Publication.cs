using YggdrAshill.Heimdallr.Inspection;
using System;

namespace YggdrAshill.Heimdallr
{
    public sealed class Publication<TItem> :
        IPublication<TItem>
        where TItem : IItem
    {
        private readonly Func<IIndication<TItem>, IUnsubscription> onSubscribed;

        #region Constructor

        public Publication(Func<IIndication<TItem>, IUnsubscription> onSubscribed)
        {
            if (onSubscribed == null)
            {
                throw new ArgumentNullException(nameof(onSubscribed));
            }

            this.onSubscribed = onSubscribed;
        }

        public Publication()
        {
            onSubscribed = (_) =>
            {
                return new Unsubscription();
            };
        }

        #endregion

        #region IPublication

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

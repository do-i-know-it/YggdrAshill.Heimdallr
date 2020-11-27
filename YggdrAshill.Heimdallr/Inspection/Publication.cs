using YggdrAshill.Heimdallr.Inspection;
using System;

namespace YggdrAshill.Heimdallr
{
    public sealed class Publication<TItem> :
        IPublication<TItem>
        where TItem : IItem
    {
        private readonly Func<IIndication<TItem>, IUnsubscription> onSubscribed;

        public Publication(Func<IIndication<TItem>, IUnsubscription> onSubscribed)
        {
            if (onSubscribed == null)
            {
                throw new ArgumentNullException(nameof(onSubscribed));
            }

            this.onSubscribed = onSubscribed;
        }

        public IUnsubscription Subscribe(IIndication<TItem> indication)
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return onSubscribed.Invoke(indication);
        }
    }
}

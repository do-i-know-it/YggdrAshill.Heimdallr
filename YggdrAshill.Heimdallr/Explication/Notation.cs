using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr
{
    public sealed class Notation<TItem> :
        INotation<TItem>
        where TItem : IInformation
    {
        private readonly Func<TItem, Note> onNotated;

        public Notation(Func<TItem, Note> onNotated)
        {
            if (onNotated == null)
            {
                throw new ArgumentNullException(nameof(onNotated));
            }

            this.onNotated = onNotated;
        }

        public Note Notate(TItem item)
        {
            return onNotated.Invoke(item);
        }
    }
}

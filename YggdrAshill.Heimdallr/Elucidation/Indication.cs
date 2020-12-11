using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr
{
    public sealed class Indication<TItem> :
        IIndication<TItem>
        where TItem : IItem
    {
        private readonly Action<TItem> onIndicated;

        #region Constructor

        public Indication(Action<TItem> onIndicated)
        {
            if (onIndicated == null)
            {
                throw new ArgumentNullException(nameof(onIndicated));
            }

            this.onIndicated = onIndicated;
        }

        public Indication()
        {
            onIndicated = (_) =>
            {

            };
        }

        #endregion

        #region IIndication

        public void Indicate(TItem item)
        {
            onIndicated.Invoke(item);
        }

        #endregion
    }
}

using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr
{
    public sealed class Unsubscription :
        IUnsubscription
    {
        private readonly Action onUnsubscribed;

        #region Constructor

        public Unsubscription(Action onUnsubscribed)
        {
            if (onUnsubscribed == null)
            {
                throw new ArgumentNullException(nameof(onUnsubscribed));
            }

            this.onUnsubscribed = onUnsubscribed;
        }

        public Unsubscription()
        {
            onUnsubscribed = () =>
            {

            };
        }

        #endregion

        #region IUnsubscription

        public void Unsubscribe()
        {
            onUnsubscribed.Invoke();
        }

        #endregion
    }
}

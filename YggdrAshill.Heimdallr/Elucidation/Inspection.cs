using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr
{
    public sealed class Inspection :
        IInspection
    {
        private readonly Action onInspected;

        #region Constructor
        
        public Inspection(Action onInspected)
        {
            if (onInspected == null)
            {
                throw new ArgumentNullException(nameof(onInspected));
            }

            this.onInspected = onInspected;
        }

        public Inspection()
        {
            onInspected = () =>
            {

            };
        }

        #endregion

        #region IInspection

        public void Inspect()
        {
            onInspected.Invoke();
        }

        #endregion
    }
}

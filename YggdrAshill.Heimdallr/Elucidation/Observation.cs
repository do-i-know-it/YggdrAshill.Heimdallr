using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr
{
    public sealed class Observation<TItem> :
        IObservation<TItem>
        where TItem : IItem
    {
        private readonly Func<IIndication<TItem>, IInspection> onObserved;

        #region Constructor

        public Observation(Func<IIndication<TItem>, IInspection> onObserved)
        {
            if (onObserved == null)
            {
                throw new ArgumentNullException(nameof(onObserved));
            }

            this.onObserved = onObserved;
        }

        public Observation()
        {
            onObserved = (_) =>
            {
                return new Inspection();
            };
        }

        #endregion

        #region IObservation

        public IInspection Observe(IIndication<TItem> indication)
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return onObserved.Invoke(indication);
        }

        #endregion
    }
}

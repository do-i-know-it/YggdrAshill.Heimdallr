using YggdrAshill.Heimdallr.Inspection;
using System;

namespace YggdrAshill.Heimdallr
{
    public sealed class Observation<TItem> :
        IObservation<TItem>
        where TItem : IItem
    {
        private readonly Func<IIndication<TItem>, IExecution> onExecuted;

        public Observation(Func<IIndication<TItem>, IExecution> onExecuted)
        {
            if (onExecuted == null)
            {
                throw new ArgumentNullException(nameof(onExecuted));
            }

            this.onExecuted = onExecuted;
        }

        public IExecution Activate(IIndication<TItem> indication)
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return onExecuted.Invoke(indication);
        }
    }
}

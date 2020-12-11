using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Inception;
using System;

namespace YggdrAshill.Heimdallr
{
    public sealed class Initiation<TItem> :
        IInitiation<TItem>
        where TItem : IItem
    {
        private readonly Func<IIndication<TItem>, IExecution> onIncepted;

        #region Constructor

        public Initiation(Func<IIndication<TItem>, IExecution> onIncepted)
        {
            if (onIncepted == null)
            {
                throw new ArgumentNullException(nameof(onIncepted));
            }

            this.onIncepted = onIncepted;
        }

        public Initiation(Func<TItem> onExecuted)
        {
            if (onExecuted == null)
            {
                throw new ArgumentNullException(nameof(onExecuted));
            }

            onIncepted = (indication) =>
            {
                return new Execution(() =>
                {
                    var executed = onExecuted.Invoke();

                    indication.Indicate(executed);
                });
            };
        }

        public Initiation()
        {
            onIncepted = (_) =>
            {
                return new Execution();
            };
        }

        #endregion

        #region IInitiation

        public IExecution Initiate(IIndication<TItem> indication)
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return onIncepted.Invoke(indication);
        }

        #endregion
    }
}

using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Inception;
using System;

namespace YggdrAshill.Heimdallr
{
    public sealed class Source<TItem> :
        ISource<TItem>
        where TItem : IItem
    {
        private readonly Func<IIndication<TItem>, IExecution> onIncepted;

        #region Constructor

        public Source(Func<IIndication<TItem>, IExecution> onIncepted)
        {
            if (onIncepted == null)
            {
                throw new ArgumentNullException(nameof(onIncepted));
            }

            this.onIncepted = onIncepted;
        }

        public Source(Func<TItem> onExecuted)
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

        public Source()
        {
            onIncepted = (_) =>
            {
                return new Execution();
            };
        }

        #endregion

        #region ISource

        public IExecution Incept(IIndication<TItem> indication)
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

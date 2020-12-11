using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Inception;
using System;

namespace YggdrAshill.Heimdallr
{
    public sealed class Inspection<TItem> :
        IInspection<TItem>
        where TItem : IItem
    {
        private readonly Func<IIndication<TItem>, IExecution> onActivated;

        #region Constructor

        public Inspection(Func<IIndication<TItem>, IExecution> onActivated)
        {
            if (onActivated == null)
            {
                throw new ArgumentNullException(nameof(onActivated));
            }

            this.onActivated = onActivated;
        }

        public Inspection(Func<TItem> onExecuted)
        {
            if (onExecuted == null)
            {
                throw new ArgumentNullException(nameof(onExecuted));
            }

            onActivated = (indication) =>
            {
                return new Execution(() =>
                {
                    var executed = onExecuted.Invoke();

                    indication.Indicate(executed);
                });
            };
        }

        public Inspection()
        {
            onActivated = (_) =>
            {
                return new Execution();
            };
        }

        #endregion

        #region IInspection

        public IExecution Activate(IIndication<TItem> indication)
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return onActivated.Invoke(indication);
        }

        #endregion
    }
}

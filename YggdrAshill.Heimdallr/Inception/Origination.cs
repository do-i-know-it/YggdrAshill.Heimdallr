using YggdrAshill.Heimdallr.Inception;
using System;

namespace YggdrAshill.Heimdallr
{
    public sealed class Origination :
        IOrigination
    {
        private readonly Func<IExecution> onOriginated;

        #region Constructor

        public Origination(Func<IExecution> onOriginated)
        {
            if (onOriginated == null)
            {
                throw new ArgumentNullException(nameof(onOriginated));
            }

            this.onOriginated = onOriginated;
        }

        public Origination()
        {
            onOriginated = () =>
            {
                return new Execution();
            };
        }

        #endregion

        #region IOrigination

        public IExecution Originate()
        {
            return onOriginated.Invoke();
        }

        #endregion
    }
}

using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr
{
    public sealed class Examination :
        IExamination
    {
        private readonly Func<IInspection> onExamined;

        #region Constructor

        public Examination(Func<IInspection> onExamined)
        {
            if (onExamined == null)
            {
                throw new ArgumentNullException(nameof(onExamined));
            }

            this.onExamined = onExamined;
        }

        public Examination()
        {
            onExamined = () =>
            {
                return new Inspection();
            };
        }

        #endregion

        #region IExamination

        public IInspection Examine()
        {
            return onExamined.Invoke();
        }

        #endregion
    }
}

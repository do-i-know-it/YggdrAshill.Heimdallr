using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr
{
    public sealed class Inspection<TItem> :
        IInspection<TItem>
        where TItem : IItem
    {
        private readonly IExecution execution;

        private readonly IAnnouncement<TItem> announcement;

        #region Constructor

        public Inspection(Func<TItem> onExecuted)
        {
            if (onExecuted == null)
            {
                throw new ArgumentNullException(nameof(onExecuted));
            }

            execution = new Execution(() =>
            {
                var executed = onExecuted.Invoke();

                announcement.Indicate(executed);
            });

            announcement = new Announcement<TItem>();
        }

        #endregion

        #region IObservation

        public IUnsubscription Subscribe(IIndication<TItem> indication)
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return announcement.Subscribe(indication);
        }

        #endregion

        #region IUnsubscription

        public void Unsubscribe()
        {
            announcement.Unsubscribe();
        }

        #endregion

        #region IOrigination

        public IExecution Originate()
        {
            return execution;
        }

        #endregion
    }
}

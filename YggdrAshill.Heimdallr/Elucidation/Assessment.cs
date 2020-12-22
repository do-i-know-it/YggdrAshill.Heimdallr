using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr
{
    public sealed class Assessment<TItem> :
        IAssessment<TItem>
        where TItem : IItem
    {
        private readonly Announcement<TItem> announcement;

        private readonly Inspection inspection;

        #region Constructor

        public Assessment(Func<TItem> onExecuted)
        {
            if (onExecuted == null)
            {
                throw new ArgumentNullException(nameof(onExecuted));
            }

            inspection = new Inspection(() =>
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

        #region IExamination

        public IInspection Examine()
        {
            return inspection;
        }

        #endregion
    }
}

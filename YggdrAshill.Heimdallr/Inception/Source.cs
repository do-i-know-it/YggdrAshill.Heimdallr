﻿using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Inception;
using System;

namespace YggdrAshill.Heimdallr
{
    public sealed class Source<TItem> :
        ISource<TItem>
        where TItem : IItem
    {
        private readonly IInitiation<TItem> initiation;

        private readonly IAnnouncement<TItem> announcement;

        #region Constructor

        public Source(Func<TItem> onExecuted)
        {
            if (onExecuted == null)
            {
                throw new ArgumentNullException(nameof(onExecuted));
            }

            initiation = new Initiation<TItem>(onExecuted);

            announcement = new Announcement<TItem>();
        }

        public Source()
        {
            initiation = new Initiation<TItem>();
         
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
            return initiation.Initiate(announcement);
        }

        #endregion
    }
}

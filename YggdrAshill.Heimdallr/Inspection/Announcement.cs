using YggdrAshill.Heimdallr.Inspection;
using System;
using System.Collections.Generic;

namespace YggdrAshill.Heimdallr
{
    public sealed class Announcement<TItem> :
        IAnnouncement<TItem>
        where TItem : IItem
    {
        private readonly List<IIndication<TItem>> indicationList
            = new List<IIndication<TItem>>();

        public void Indicate(TItem item)
        {
            foreach (var indication in indicationList)
            {
                indication.Indicate(item);
            }
        }

        public IUnsubscription Subscribe(IIndication<TItem> indication)
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            if (!indicationList.Contains(indication))
            {
                indicationList.Add(indication);
            }

            return new Unsubscription(() =>
            {
                if (indicationList.Contains(indication))
                {
                    indicationList.Remove(indication);
                }
            });
        }

        public void Unsubscribe()
        {
            indicationList.Clear();
        }
    }
}

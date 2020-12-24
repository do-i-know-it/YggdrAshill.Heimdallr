using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Explication
{
    internal sealed class Notify<TItem> :
        IIndication<TItem>
        where TItem : IItem
    {
        private readonly IIndication<Notice> indication;

        private readonly INotification<TItem> notification;

        internal Notify(IIndication<Notice> indication, INotification<TItem> notification)
        {
            this.indication = indication;

            this.notification = notification;
        }

        public void Indicate(TItem item)
        {
            if (!notification.Notify(item))
            {
                return;
            }

            indication.Indicate(Notice.Instance);
        }
    }
}

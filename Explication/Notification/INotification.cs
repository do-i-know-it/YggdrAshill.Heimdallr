using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Explication
{
    public interface INotification<TItem>
        where TItem : IItem
    {
        bool Notify(TItem item);
    }
}

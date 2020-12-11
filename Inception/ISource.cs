using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Inception
{
    public interface ISource<TItem> :
        IObservation<TItem>,
        IUnsubscription,
        IOrigination
        where TItem : IItem
    {

    }
}

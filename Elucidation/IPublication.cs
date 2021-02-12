namespace YggdrAshill.Heimdallr.Elucidation
{
    public interface IPublication<TItem> :
        IIndication<TItem>,
        ISubscription<TItem>,
        IUnsubscription
        where TItem : IItem
    {

    }
}

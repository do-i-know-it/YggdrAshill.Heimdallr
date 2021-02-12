namespace YggdrAshill.Heimdallr.Elucidation
{
    public interface ISubscription<TItem>
        where TItem : IItem
    {
        IUnsubscription Subscribe(IIndication<TItem> indication);
    }
}

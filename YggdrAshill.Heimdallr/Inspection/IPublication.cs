namespace YggdrAshill.Heimdallr.Inspection
{
    public interface IPublication<TItem>
        where TItem : IItem
    {
        IUnsubscription Subscribe(IIndication<TItem> indication);
    }
}

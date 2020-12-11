namespace YggdrAshill.Heimdallr.Elucidation
{
    public interface IObservation<TItem>
        where TItem : IItem
    {
        IUnsubscription Subscribe(IIndication<TItem> indication);
    }
}

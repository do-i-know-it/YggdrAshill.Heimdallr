namespace YggdrAshill.Heimdallr.Elucidation
{
    public interface IAnnouncement<TItem> :
        IIndication<TItem>,
        IObservation<TItem>,
        IUnsubscription
        where TItem : IItem
    {

    }
}

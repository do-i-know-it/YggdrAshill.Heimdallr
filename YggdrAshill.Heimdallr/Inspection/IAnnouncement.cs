namespace YggdrAshill.Heimdallr.Inspection
{
    public interface IAnnouncement<TItem> :
        IIndication<TItem>,
        IPublication<TItem>,
        IUnsubscription
        where TItem : IItem
    {

    }
}

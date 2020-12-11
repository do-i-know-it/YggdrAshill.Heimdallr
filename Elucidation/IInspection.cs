namespace YggdrAshill.Heimdallr.Elucidation
{
    public interface IInspection<TItem> :
        IObservation<TItem>,
        IUnsubscription,
        IOrigination
        where TItem : IItem
    {

    }
}

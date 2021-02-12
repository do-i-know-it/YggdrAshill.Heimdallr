namespace YggdrAshill.Heimdallr.Elucidation
{
    public interface IObservation<TItem>
        where TItem : IItem
    {
        IInspection Observe(IIndication<TItem> indication);
    }
}

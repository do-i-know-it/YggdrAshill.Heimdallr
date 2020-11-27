namespace YggdrAshill.Heimdallr.Inspection
{
    public interface IObservation<TItem>
        where TItem : IItem
    {
        IExecution Activate(IIndication<TItem> indication);
    }
}

namespace YggdrAshill.Heimdallr.Inspection
{
    public interface IIndication<TItem>
        where TItem : IItem
    {
        void Indicate(TItem item);
    }
}

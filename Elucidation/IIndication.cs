namespace YggdrAshill.Heimdallr.Elucidation
{
    public interface IIndication<TItem>
        where TItem : IItem
    {
        void Indicate(TItem item);
    }
}

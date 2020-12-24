using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Explication
{
    public interface INotation<TItem>
        where TItem : IItem
    {
        Note Notate(TItem item);
    }
}

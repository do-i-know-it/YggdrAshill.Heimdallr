using YggdrAshill.Heimdallr.Inspection;

namespace YggdrAshill.Heimdallr.Conversion
{
    public interface INotation<TItem>
        where TItem : IItem
    {
        Note Notate(TItem item);
    }
}

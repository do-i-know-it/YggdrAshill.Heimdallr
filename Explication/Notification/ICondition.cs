using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Explication
{
    public interface ICondition<TItem>
        where TItem : IItem
    {
        bool IsSatisfied(TItem item);
    }
}

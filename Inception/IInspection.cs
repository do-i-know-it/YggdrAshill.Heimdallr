using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Inception
{
    public interface IInspection<TItem>
        where TItem : IItem
    {
        IExecution Activate(IIndication<TItem> indication);
    }
}

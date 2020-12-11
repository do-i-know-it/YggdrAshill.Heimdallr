using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Incepction
{
    public interface ISource<TItem>
        where TItem : IItem
    {
        IExecution Incept(IIndication<TItem> indication);
    }
}

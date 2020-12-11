using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Inception
{
    public interface IInitiation<TItem>
        where TItem : IItem
    {
        IExecution Initiate(IIndication<TItem> indication);
    }
}

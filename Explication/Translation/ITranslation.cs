using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Explication
{
    public interface ITranslation<TInput, TOutput>
        where TInput : IItem
        where TOutput : IItem
    {
        TOutput Translate(TInput item);
    }
}

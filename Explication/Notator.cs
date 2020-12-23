using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Explication
{
    internal sealed class Notator<TItem> :
        ITranslation<TItem, Note>
        where TItem : IItem
    {
        private readonly INotation<TItem> notation;

        public Notator(INotation<TItem> notation)
        {
            this.notation = notation;
        }

        public Note Translate(TItem item)
        {
            return notation.Notate(item);
        }
    }
}

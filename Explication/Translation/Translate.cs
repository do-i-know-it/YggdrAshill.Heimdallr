using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Explication
{
    internal sealed class Translate<TInput, TOutput> :
        IIndication<TInput>
        where TInput : IItem
        where TOutput : IItem
    {
        private readonly IIndication<TOutput> indication;

        private readonly ITranslation<TInput, TOutput> translation;

        public Translate(IIndication<TOutput> indication, ITranslation<TInput, TOutput> translation)
        {
            this.indication = indication;

            this.translation = translation;
        }

        public void Indicate(TInput item)
        {
            var translated = translation.Translate(item);

            indication.Indicate(translated);
        }
    }
}

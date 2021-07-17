using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr
{
    public sealed class Translation<TInput, TOutput> :
        ITranslation<TInput, TOutput>
        where TInput : IInformation
        where TOutput : IInformation
    {
        private readonly Func<TInput, TOutput> onTranslated;

        public Translation(Func<TInput, TOutput> onTranslated)
        {
            if (onTranslated == null)
            {
                throw new ArgumentNullException(nameof(onTranslated));
            }

            this.onTranslated = onTranslated;
        }

        public TOutput Translate(TInput item)
        {
            return onTranslated.Invoke(item);
        }
    }
}

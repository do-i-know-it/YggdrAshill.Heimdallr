using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Explication
{
    internal sealed class Translator<TInput, TOutput> :
        ISubscription<TOutput>
        where TInput : IItem
        where TOutput : IItem
    {
        private readonly ISubscription<TInput> subscription;

        private readonly ITranslation<TInput, TOutput> translation;

        public Translator(ISubscription<TInput> subscription, ITranslation<TInput, TOutput> translation)
        {
            this.subscription = subscription;

            this.translation = translation;
        }

        public IUnsubscription Subscribe(IIndication<TOutput> indication)
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return subscription.Subscribe(new Translate<TInput, TOutput>(indication, translation));
        }
    }
}

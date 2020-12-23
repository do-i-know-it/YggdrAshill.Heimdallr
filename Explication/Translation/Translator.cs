using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Explication
{
    internal sealed class Translator<TInput, TOutput> :
        IObservation<TOutput>
        where TInput : IItem
        where TOutput : IItem
    {
        private readonly IObservation<TInput> observation;

        private readonly ITranslation<TInput, TOutput> translation;

        public Translator(IObservation<TInput> observation, ITranslation<TInput, TOutput> translation)
        {
            this.observation = observation;

            this.translation = translation;
        }

        public IUnsubscription Subscribe(IIndication<TOutput> indication)
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return observation.Subscribe(new Translate<TInput, TOutput>(indication, translation));
        }
    }
}

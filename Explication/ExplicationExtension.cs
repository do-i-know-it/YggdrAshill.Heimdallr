using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Explication
{
    public static class ExplicationExtension
    {
        public static IObservation<TOutput> Translate<TInput, TOutput>(this IObservation<TInput> observation, ITranslation<TInput, TOutput> translation)
            where TInput : IItem
            where TOutput : IItem
        {
            if (observation == null)
            {
                throw new ArgumentNullException(nameof(observation));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new Translator<TInput, TOutput>(observation, translation);
        }

        public static IObservation<Note> Notate<TItem>(this IObservation<TItem> observation, INotation<TItem> notation)
            where TItem : IItem
        {
            if (observation == null)
            {
                throw new ArgumentNullException(nameof(observation));
            }
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return observation.Translate(new Notator<TItem>(notation));
        }
    }
}

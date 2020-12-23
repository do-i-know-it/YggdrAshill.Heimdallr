using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Explication
{
    public static class ExplicationExtension
    {
        #region Translation

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

        public static IIndication<TInput> Translated<TInput, TOutput>(this IIndication<TOutput> indication, ITranslation<TInput, TOutput> translation)
            where TInput : IItem
            where TOutput : IItem
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new Translate<TInput, TOutput>(indication, translation);
        }

        #endregion

        #region Notation

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

            return observation.Translate(new Notate<TItem>(notation));
        }

        public static IIndication<TItem> Notated<TItem>(this IIndication<Note> indication, INotation<TItem> notation)
            where TItem : IItem
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return indication.Translated(new Notate<TItem>(notation));
        }

        #endregion
    }
}

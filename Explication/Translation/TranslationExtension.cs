using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Explication
{
    /// <summary>
    /// Defines extensions for <see cref="ITranslation{TInput, TOutput}"/>.
    /// </summary>
    public static class TranslationExtension
    {
        /// <summary>
        /// Translates <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="IInformation"/> for input.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="IInformation"/> for output.
        /// </typeparam>
        /// <param name="indication">
        /// <see cref="IIndication{TInformation}"/> to send <typeparamref name="TOutput"/>.
        /// </param>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to translate.
        /// </param>
        /// <returns>
        /// <see cref="IIndication{TInformation}"/> to send <typeparamref name="TInput"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="indication"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static IIndication<TInput> Translate<TInput, TOutput>(this IIndication<TOutput> indication, ITranslation<TInput, TOutput> translation)
            where TInput : IInformation
            where TOutput : IInformation
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new Indication<TInput, TOutput>(translation, indication);
        }
        private sealed class Indication<TInput, TOutput> :
            IIndication<TInput>
            where TInput : IInformation
            where TOutput : IInformation
        {
            private readonly IIndication<TOutput> indication;

            private readonly ITranslation<TInput, TOutput> translation;

            internal Indication(ITranslation<TInput, TOutput> translation, IIndication<TOutput> indication)
            {
                this.indication = indication;

                this.translation = translation;
            }

            /// <inheritdoc/>
            public void Indicate(TInput item)
            {
                var translated = translation.Translate(item);

                indication.Indicate(translated);
            }
        }

        /// <summary>
        /// Translates <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="IInformation"/> for input.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="IInformation"/> for output.
        /// </typeparam>
        /// <param name="observation">
        /// <see cref="IObservation{TInformation}"/> to send <typeparamref name="TInput"/>.
        /// </param>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to translate.
        /// </param>
        /// <returns>
        /// <see cref="IObservation{TInformation}"/> to send <typeparamref name="TOutput"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="observation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static IObservation<TOutput> Translate<TInput, TOutput>(this IObservation<TInput> observation, ITranslation<TInput, TOutput> translation)
            where TInput : IInformation
            where TOutput : IInformation
        {
            if (observation == null)
            {
                throw new ArgumentNullException(nameof(observation));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new Observation<TInput, TOutput>(observation, translation);
        }
        private sealed class Observation<TInput, TOutput> :
            IObservation<TOutput>
            where TInput : IInformation
            where TOutput : IInformation
        {
            private readonly IObservation<TInput> observation;

            private readonly ITranslation<TInput, TOutput> translation;

            internal Observation(IObservation<TInput> observation, ITranslation<TInput, TOutput> translation)
            {
                this.observation = observation;

                this.translation = translation;
            }

            /// <inheritdoc/>
            public IInspection Observe(IIndication<TOutput> indication)
            {
                if (indication == null)
                {
                    throw new ArgumentNullException(nameof(indication));
                }

                return observation.Observe(indication.Translate(translation));
            }
        }
    }
}

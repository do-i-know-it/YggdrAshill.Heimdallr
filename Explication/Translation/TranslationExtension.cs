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
        /// Translates <typeparamref name="TValue"/> into <see cref="Note"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to notate.
        /// </typeparam>
        /// <param name="indication">
        /// <see cref="IIndication{TValue}"/> to receive <see cref="Note"/>.
        /// </param>
        /// <param name="notation">
        /// <see cref="INotation{TValue}"/> to notate.
        /// </param>
        /// <returns>
        /// <see cref="IIndication{TValue}"/> to receive <typeparamref name="TValue"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="indication"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notation"/> is null.
        /// </exception>
        public static IIndication<TValue> Translate<TValue>(this IIndication<Note> indication, INotation<TValue> notation)
            where TValue : IValue
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return new Indication<TValue>(notation, indication);
        }
        private sealed class Indication<TValue> :
            IIndication<TValue>
            where TValue : IValue
        {
            private readonly INotation<TValue> notation;

            private readonly IIndication<Note> indication;

            internal Indication(INotation<TValue> notation, IIndication<Note> indication)
            {
                this.notation = notation;

                this.indication = indication;
            }

            /// <inheritdoc/>
            public void Indicate(TValue value)
            {
                var note = notation.Notate(value);

                indication.Indicate(note);
            }
        }

        /// <summary>
        /// Translates <typeparamref name="TValue"/> into <see cref="Note"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to notate.
        /// </typeparam>
        /// <param name="observation">
        /// <see cref="IObservation{TValue}"/> to send <typeparamref name="TValue"/>.
        /// </param>
        /// <param name="notation">
        /// <see cref="INotation{TValue}"/> to notate.
        /// </param>
        /// <returns>
        /// <see cref="IObservation{TValue}"/> to send <see cref="Note"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="observation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notation"/> is null.
        /// </exception>
        public static IObservation<Note> Translate<TValue>(this IObservation<TValue> observation, INotation<TValue> notation)
            where TValue : IValue
        {
            if (observation == null)
            {
                throw new ArgumentNullException(nameof(observation));
            }
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return new Observation<TValue>(observation, notation);
        }
        private sealed class Observation<TValue> :
            IObservation<Note>
            where TValue : IValue
        {
            private readonly IObservation<TValue> observation;

            private readonly INotation<TValue> notation;

            internal Observation(IObservation<TValue> observation, INotation<TValue> notation)
            {
                this.observation = observation;

                this.notation = notation;
            }

            /// <inheritdoc/>
            public IInspection Observe(IIndication<Note> indication)
            {
                if (indication == null)
                {
                    throw new ArgumentNullException(nameof(indication));
                }

                return observation.Observe(indication.Translate(notation));
            }
        }
    }
}

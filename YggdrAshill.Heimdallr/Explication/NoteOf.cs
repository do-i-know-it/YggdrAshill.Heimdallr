using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr
{
    /// <summary>
    /// Defines implementations for <see cref="INotation{TValue}"/>.
    /// </summary>
    public static class NoteOf
    {
        /// <summary>
        /// Translates <typeparamref name="TValue"/> into <see cref="Explication.Note"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to notate.
        /// </typeparam>
        /// <param name="notation">
        /// <see cref="Func{T, TResult}"/> to translate <typeparamref name="TValue"/> into <see cref="Explication.Note"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotation{TValue}"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notation"/> is null.
        /// </exception>
        public static INotation<TValue> Value<TValue>(Func<TValue, Note> notation)
            where TValue : IValue
        {
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return new Notation<TValue>(notation);
        }
        private sealed class Notation<TValue> :
            INotation<TValue>
            where TValue : IValue
        {
            private readonly Func<TValue, Note> onNotated;

            internal Notation(Func<TValue, Note> onNotated)
            {
                this.onNotated = onNotated;
            }

            /// <inheritdoc/>
            public Note Notate(TValue value)
            {
                return onNotated.Invoke(value);
            }
        }

        /// <summary>
        /// Translates <see cref="Explication.Note"/> into <see cref="Explication.Note"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to notate.
        /// </typeparam>
        /// <param name="notation">
        /// <see cref="Func{T, TResult}"/> to decorate <see cref="string"/> of <see cref="Explication.Note.Content"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotation{TValue}"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notation"/> is null.
        /// </exception>
        public static INotation<Note> Note(Func<string, string> notation)
        {
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return Value<Note>(value =>
            {
                var content = notation.Invoke(value.Content);

                return new Note(content);
            });
        }
    }
}

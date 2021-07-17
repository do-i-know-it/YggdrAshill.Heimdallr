using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Explication
{
    /// <summary>
    /// Defines extensions for <see cref="INotation{TInformation}"/>.
    /// </summary>
    public static class NotationExtension
    {
        /// <summary>
        /// Converts <see cref="INotation{TInformation}"/> into <see cref="ITranslation{TInput, TOutput}"/>.
        /// </summary>
        /// <typeparam name="TInformation">
        /// Type of <see cref="IInformation"/> to translate.
        /// </typeparam>
        /// <param name="notation">
        /// <see cref="INotation{TInformation}"/> to notate.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TInformation"/> into <see cref="Note"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notation"/> is null.
        /// </exception>
        public static ITranslation<TInformation, Note> Translate<TInformation>(this INotation<TInformation> notation)
            where TInformation : IInformation
        {
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return new Translation<TInformation>(notation);
        }
        private sealed class Translation<TInformation> :
            ITranslation<TInformation, Note>
            where TInformation : IInformation
        {
            private readonly INotation<TInformation> notation;

            internal Translation(INotation<TInformation> notation)
            {
                this.notation = notation;
            }

            /// <inheritdoc/>
            public Note Translate(TInformation information)
            {
                return notation.Notate(information);
            }
        }
    }
}

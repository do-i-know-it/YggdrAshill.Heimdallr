using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr
{
    /// <summary>
    /// Defines implementations of <see cref="IIndication{TInformation}"/>.
    /// </summary>
    public static class Indication
    {
        /// <summary>
        /// Executes <see cref="Action{T}"/>.
        /// </summary>
        /// <typeparam name="TInformation">
        /// Type of <see cref="IInformation"/> to indicate.
        /// </typeparam>
        /// <param name="indication">
        /// <see cref="Action{T}"/> to indicate <typeparamref name="TInformation"/>.
        /// </param>
        /// <returns>
        /// <see cref="IIndication{TInformation}"/> created.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="indication"/> is null.
        /// </exception>
        public static IIndication<TInformation> Of<TInformation>(Action<TInformation> indication)
            where TInformation : IInformation
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return new Created<TInformation>(indication);
        }
        private sealed class Created<TInformation> :
            IIndication<TInformation>
            where TInformation : IInformation
        {
            private readonly Action<TInformation> onIndicated;

            internal Created(Action<TInformation> onIndicated)
            {
                this.onIndicated = onIndicated;
            }

            /// <inheritdoc/>
            public void Indicate(TInformation information)
            {
                onIndicated.Invoke(information);
            }
        }

        /// <summary>
        /// Executes none.
        /// </summary>
        /// <typeparam name="TInformation">
        /// Type of <see cref="IInformation"/> to indicate.
        /// </typeparam>
        /// <returns>
        /// <see cref="IIndication{TInformation}"/> created.
        /// </returns>
        public static IIndication<TInformation> None<TInformation>()
            where TInformation : IInformation
        {
            return Of<TInformation>(_ => { });
        }
    }
}

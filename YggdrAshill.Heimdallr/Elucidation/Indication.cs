using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr
{
    /// <summary>
    /// Defines implementations of <see cref="IIndication{TValue}"/>.
    /// </summary>
    public static class Indication
    {
        /// <summary>
        /// Executes <see cref="Action{T}"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to indicate.
        /// </typeparam>
        /// <param name="indication">
        /// <see cref="Action{T}"/> to indicate <typeparamref name="TValue"/>.
        /// </param>
        /// <returns>
        /// <see cref="IIndication{TValue}"/> created.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="indication"/> is null.
        /// </exception>
        public static IIndication<TValue> Of<TValue>(Action<TValue> indication)
            where TValue : IValue
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return new Created<TValue>(indication);
        }
        private sealed class Created<TValue> :
            IIndication<TValue>
            where TValue : IValue
        {
            private readonly Action<TValue> onIndicated;

            internal Created(Action<TValue> onIndicated)
            {
                this.onIndicated = onIndicated;
            }

            /// <inheritdoc/>
            public void Indicate(TValue value)
            {
                onIndicated.Invoke(value);
            }
        }

        /// <summary>
        /// Executes none.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to indicate.
        /// </typeparam>
        /// <returns>
        /// <see cref="IIndication{TValue}"/> created.
        /// </returns>
        public static IIndication<TValue> None<TValue>()
            where TValue : IValue
        {
            return Of<TValue>(_ => { });
        }
    }
}

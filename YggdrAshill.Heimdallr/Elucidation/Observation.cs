using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr
{
    /// <summary>
    /// Defines implementations of <see cref="IObservation{TValue}"/>.
    /// </summary>
    public static class Observation
    {
        /// <summary>
        /// Sends <typeparamref name="TValue"/> generated by <see cref="Func{TResult}"/> to <see cref="IIndication{TValue}"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to observe.
        /// </typeparam>
        /// <param name="evaluation">
        /// <see cref="Func{TResult}"/> to evaluate <typeparamref name="TValue"/>.
        /// </param>
        /// <returns>
        /// <see cref="IObservation{TValue}"/> created.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="evaluation"/> is null.
        /// </exception>
        public static IObservation<TValue> Of<TValue>(Func<TValue> evaluation)
            where TValue : IValue
        {
            if (evaluation == null)
            {
                throw new ArgumentNullException(nameof(evaluation));
            }

            return new Created<TValue>(evaluation);
        }
        private sealed class Created<TValue> :
            IObservation<TValue>
            where TValue : IValue
        {
            private readonly Func<TValue> onEvaluated;

            internal Created(Func<TValue> onEvaluated)
            {
                this.onEvaluated = onEvaluated;
            }

            /// <inheritdoc/>
            public IInspection Observe(IIndication<TValue> indication)
            {
                if (indication == null)
                {
                    throw new ArgumentNullException(nameof(indication));
                }

                return new Inspection<TValue>(onEvaluated, indication);
            }
        }
        private sealed class Inspection<TValue> :
            IInspection
            where TValue : IValue
        {
            private readonly Func<TValue> onEvaluated;

            private readonly IIndication<TValue> indication;

            internal Inspection(Func<TValue> onEvaluated, IIndication<TValue> indication)
            {
                this.onEvaluated = onEvaluated;

                this.indication = indication;
            }

            /// <inheritdoc/>
            public void Inspect()
            {
                var value = onEvaluated.Invoke();

                indication.Indicate(value);
            }
        }

        /// <summary>
        /// Sends same <typeparamref name="TValue"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to observe.
        /// </typeparam>
        /// <param name="value">
        /// <typeparamref name="TValue"/> evaluated.
        /// </param>
        /// <returns>
        /// <see cref="IObservation{TValue}"/>.
        /// </returns>
        public static IObservation<TValue> Of<TValue>(TValue value)
            where TValue : IValue
        {
            return Of(() => value);
        }
    }
}

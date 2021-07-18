using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr
{
    /// <summary>
    /// Defines implementations of <see cref="IEvaluation{TValue}"/>.
    /// </summary>
    public static class Evaluation
    {
        /// <summary>
        /// Executes <see cref="Func{TResult}"/> to evaluate <typeparamref name="TValue"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to evaluate.
        /// </typeparam>
        /// <param name="evaluation">
        /// <see cref="Func{TResult}"/> to evaluate <typeparamref name="TValue"/>.
        /// </param>
        /// <returns>
        /// <see cref="IEvaluation{TValue}"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="evaluation"/> is null.
        /// </exception>
        public static IEvaluation<TValue> Of<TValue>(Func<TValue> evaluation)
            where TValue : IValue
        {
            if (evaluation == null)
            {
                throw new ArgumentNullException(nameof(evaluation));
            }

            return new Created<TValue>(evaluation);
        }
        private sealed class Created<TValue> :
            IEvaluation<TValue>
            where TValue : IValue
        {
            private readonly Func<TValue> onEvaluated;

            internal Created(Func<TValue> onEvaluated)
            {
                this.onEvaluated = onEvaluated;
            }

            /// <inheritdoc/>
            public TValue Evaluate()
            {
                return onEvaluated.Invoke();
            }
        }

        /// <summary>
        /// Evaluates same <typeparamref name="TValue"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to evaluate.
        /// </typeparam>
        /// <param name="value">
        /// <typeparamref name="TValue"/> to evaluate.
        /// </param>
        /// <returns>
        /// <see cref="IEvaluation{TValue}"/>.
        /// </returns>
        public static IEvaluation<TValue> Of<TValue>(TValue value)
            where TValue : IValue
        {
            return Of(() => value);
        }
    }
}

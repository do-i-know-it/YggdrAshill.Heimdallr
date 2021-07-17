using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr
{
    /// <summary>
    /// Defines implementations of <see cref="IEvaluation{TInformation}"/>.
    /// </summary>
    public static class Evaluation
    {
        /// <summary>
        /// Executes <see cref="Func{TResult}"/> to evaluate <typeparamref name="TInformation"/>.
        /// </summary>
        /// <typeparam name="TInformation">
        /// Type of <see cref="IInformation"/> to evaluate.
        /// </typeparam>
        /// <param name="evaluation">
        /// <see cref="Func{TResult}"/> to evaluate <typeparamref name="TInformation"/>.
        /// </param>
        /// <returns>
        /// <see cref="IEvaluation{TInformation}"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="evaluation"/> is null.
        /// </exception>
        public static IEvaluation<TInformation> Of<TInformation>(Func<TInformation> evaluation)
            where TInformation : IInformation
        {
            if (evaluation == null)
            {
                throw new ArgumentNullException(nameof(evaluation));
            }

            return new Created<TInformation>(evaluation);
        }
        private sealed class Created<TInformation> :
            IEvaluation<TInformation>
            where TInformation : IInformation
        {
            private readonly Func<TInformation> onEvaluated;

            internal Created(Func<TInformation> onEvaluated)
            {
                this.onEvaluated = onEvaluated;
            }

            /// <inheritdoc/>
            public TInformation Evaluate()
            {
                return onEvaluated.Invoke();
            }
        }

        /// <summary>
        /// Evaluates same <typeparamref name="TInformation"/>.
        /// </summary>
        /// <typeparam name="TInformation">
        /// Type of <see cref="IInformation"/> to evaluate.
        /// </typeparam>
        /// <param name="information">
        /// <typeparamref name="TInformation"/> to evaluate.
        /// </param>
        /// <returns>
        /// <see cref="IEvaluation{TInformation}"/>.
        /// </returns>
        public static IEvaluation<TInformation> Of<TInformation>(TInformation information)
            where TInformation : IInformation
        {
            return Of(() => information);
        }
    }
}

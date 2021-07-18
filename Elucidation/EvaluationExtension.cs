using System;

namespace YggdrAshill.Heimdallr.Elucidation
{
    /// <summary>
    /// Defines extensions for <see cref="IEvaluation{TValue}"/>.
    /// </summary>
    public static class EvaluationExtension
    {
        /// <summary>
        /// Observes <see cref="IIndication{TValue}"/> with <see cref="IEvaluation{TValue}"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to observe.
        /// </typeparam>
        /// <param name="evaluation">
        /// <see cref="IEvaluation{TValue}"/> to send <typeparamref name="TValue"/>.
        /// </param>
        /// <param name="indication">
        /// <see cref="IIndication{TValue}"/> to receive <typeparamref name="TValue"/>.
        /// </param>
        /// <returns>
        /// <see cref="IInspection"/> to inspect.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="evaluation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="indication"/> is null.
        /// </exception>
        public static IInspection Observe<TValue>(this IEvaluation<TValue> evaluation, IIndication<TValue> indication)
            where TValue : IValue
        {
            if (evaluation == null)
            {
                throw new ArgumentNullException(nameof(evaluation));
            }
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return new Inspection<TValue>(evaluation, indication);
        }
        private sealed class Inspection<TValue> :
            IInspection
            where TValue : IValue
        {
            private readonly IEvaluation<TValue> evaluation;

            private readonly IIndication<TValue> indication;

            internal Inspection(IEvaluation<TValue> evaluation, IIndication<TValue> indication)
            {
                this.evaluation = evaluation;

                this.indication = indication;
            }

            /// <inheritdoc/>
            public void Inspect()
            {
                var value = evaluation.Evaluate();

                indication.Indicate(value);
            }
        }

        /// <summary>
        /// Converts <see cref="IEvaluation{TValue}"/> into <see cref="IObservation{TValue}"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to observe.
        /// </typeparam>
        /// <param name="evaluation">
        /// <see cref="IEvaluation{TValue}"/> to send <typeparamref name="TValue"/>.
        /// </param>
        /// <returns>
        /// <see cref="IObservation{TValue}"/> converted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="evaluation"/> is null.
        /// </exception>
        public static IObservation<TValue> Observe<TValue>(this IEvaluation<TValue> evaluation)
            where TValue : IValue
        {
            if (evaluation == null)
            {
                throw new ArgumentNullException(nameof(evaluation));
            }

            return new Observation<TValue>(evaluation);
        }
        private sealed class Observation<TValue> :
            IObservation<TValue>
            where TValue : IValue
        {
            private readonly IEvaluation<TValue> evaluation;

            internal Observation(IEvaluation<TValue> evaluation)
            {
                this.evaluation = evaluation;
            }

            /// <inheritdoc/>
            public IInspection Observe(IIndication<TValue> indication)
            {
                if (indication == null)
                {
                    throw new ArgumentNullException(nameof(indication));
                }

                return evaluation.Observe(indication);
            }
        }
    }
}

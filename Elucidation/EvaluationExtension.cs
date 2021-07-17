using System;

namespace YggdrAshill.Heimdallr.Elucidation
{
    /// <summary>
    /// Defines extensions for <see cref="IEvaluation{TInformation}"/>.
    /// </summary>
    public static class EvaluationExtension
    {
        /// <summary>
        /// Observes <see cref="IIndication{TInformation}"/> with <see cref="IEvaluation{TInformation}"/>.
        /// </summary>
        /// <typeparam name="TInformation">
        /// Type of <see cref="IInformation"/> to observe.
        /// </typeparam>
        /// <param name="evaluation">
        /// <see cref="IEvaluation{TInformation}"/> to send <typeparamref name="TInformation"/>.
        /// </param>
        /// <param name="indication">
        /// <see cref="IIndication{TInformation}"/> to receive <typeparamref name="TInformation"/>.
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
        public static IInspection Observe<TInformation>(this IEvaluation<TInformation> evaluation, IIndication<TInformation> indication)
            where TInformation : IInformation
        {
            if (evaluation == null)
            {
                throw new ArgumentNullException(nameof(evaluation));
            }
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return new Inspection<TInformation>(evaluation, indication);
        }
        private sealed class Inspection<TInformation> :
            IInspection
            where TInformation : IInformation
        {
            private readonly IEvaluation<TInformation> evaluation;

            private readonly IIndication<TInformation> indication;

            internal Inspection(IEvaluation<TInformation> evaluation, IIndication<TInformation> indication)
            {
                this.evaluation = evaluation;

                this.indication = indication;
            }

            /// <inheritdoc/>
            public void Inspect()
            {
                var information = evaluation.Evaluate();

                indication.Indicate(information);
            }
        }

        /// <summary>
        /// Converts <see cref="IEvaluation{TInformation}"/> into <see cref="IObservation{TInformation}"/>.
        /// </summary>
        /// <typeparam name="TInformation">
        /// Type of <see cref="IInformation"/> to observe.
        /// </typeparam>
        /// <param name="evaluation">
        /// <see cref="IEvaluation{TInformation}"/> to send <typeparamref name="TInformation"/>.
        /// </param>
        /// <returns>
        /// <see cref="IObservation{TInformation}"/> converted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="evaluation"/> is null.
        /// </exception>
        public static IObservation<TInformation> Observe<TInformation>(this IEvaluation<TInformation> evaluation)
            where TInformation : IInformation
        {
            if (evaluation == null)
            {
                throw new ArgumentNullException(nameof(evaluation));
            }

            return new Observation<TInformation>(evaluation);
        }
        private sealed class Observation<TInformation> :
            IObservation<TInformation>
            where TInformation : IInformation
        {
            private readonly IEvaluation<TInformation> evaluation;

            internal Observation(IEvaluation<TInformation> evaluation)
            {
                this.evaluation = evaluation;
            }

            /// <inheritdoc/>
            public IInspection Observe(IIndication<TInformation> indication)
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

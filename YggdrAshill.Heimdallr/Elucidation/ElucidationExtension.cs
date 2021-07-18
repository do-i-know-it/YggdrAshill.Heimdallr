using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr
{
    /// <summary>
    /// Defines extensions for Elucidation.
    /// </summary>
    public static class ElucidationExtension
    {
        /// <summary>
        /// Observes <see cref="Action{T}"/> with <see cref="IEvaluation{TValue}"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to indicate.
        /// </typeparam>
        /// <param name="evaluation">
        /// <see cref="IEvaluation{TValue}"/> to send <typeparamref name="TValue"/>.
        /// </param>
        /// <param name="indication">
        /// <see cref="Action{T}"/> to receive <typeparamref name="TValue"/>.
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
        public static IInspection Observe<TValue>(this IEvaluation<TValue> evaluation, Action<TValue> indication)
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

            return evaluation.Observe(Indication.Of(indication));
        }

        /// <summary>
        /// Sends <typeparamref name="TValue"/> to <see cref="Action{T}"/>.
        /// </summary>
        /// <param name="observation">
        /// <see cref="IObservation{TValue}"/> to send <typeparamref name="TValue"/>.
        /// </param>
        /// <param name="indication">
        /// <see cref="Action{T}"/> to receive <typeparamref name="TValue"/>.
        /// </param>
        /// <returns>
        /// <see cref="IInspection"/> to inspect.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="observation"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="indication"/> is null.
        /// </exception>
        public static IInspection Observe<TValue>(this IObservation<TValue> observation, Action<TValue> indication)
            where TValue : IValue
        {
            if (observation == null)
            {
                throw new ArgumentNullException(nameof(observation));
            }
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return observation.Observe(Indication.Of(indication));
        }
    }
}

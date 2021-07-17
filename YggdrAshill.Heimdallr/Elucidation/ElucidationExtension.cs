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
        /// Observes <see cref="Action{T}"/> with <see cref="IEvaluation{TInformation}"/>.
        /// </summary>
        /// <typeparam name="TInformation">
        /// Type of <see cref="IInformation"/> to indicate.
        /// </typeparam>
        /// <param name="evaluation">
        /// <see cref="IEvaluation{TInformation}"/> to send <typeparamref name="TInformation"/>.
        /// </param>
        /// <param name="indication">
        /// <see cref="Action{T}"/> to receive <typeparamref name="TInformation"/>.
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
        public static IInspection Observe<TInformation>(this IEvaluation<TInformation> evaluation, Action<TInformation> indication)
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

            return evaluation.Observe(Indication.Of(indication));
        }

        /// <summary>
        /// Sends <typeparamref name="TInformation"/> to <see cref="Action{T}"/>.
        /// </summary>
        /// <param name="observation">
        /// <see cref="IObservation{TInformation}"/> to send <typeparamref name="TInformation"/>.
        /// </param>
        /// <param name="indication">
        /// <see cref="Action{T}"/> to receive <typeparamref name="TInformation"/>.
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
        public static IInspection Observe<TInformation>(this IObservation<TInformation> observation, Action<TInformation> indication)
            where TInformation : IInformation
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

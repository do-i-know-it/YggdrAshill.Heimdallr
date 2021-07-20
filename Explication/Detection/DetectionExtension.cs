using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Explication
{
    public static class DetectionExtension
    {
        /// <summary>
        /// Detects <see cref="Notice"/> of <typeparamref name="TValue"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to detect.
        /// </typeparam>
        /// <param name="indication">
        /// <see cref="IIndication{TValue}"/> for <see cref="Notice"/> detected.
        /// </param>
        /// <param name="condition">
        /// <see cref="ICondition{TValue}"/> to detect.
        /// </param>
        /// <returns>
        /// <see cref="IIndication{TValue}"/> to detect <typeparamref name="TValue"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="indication"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static IIndication<TValue> Detect<TValue>(this IIndication<Notice> indication, ICondition<TValue> condition)
            where TValue : IValue
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return new Indication<TValue>(condition, indication);
        }
        private sealed class Indication<TValue> :
            IIndication<TValue>
            where TValue : IValue
        {
            private readonly ICondition<TValue> condition;

            private readonly IIndication<Notice> indication;

            internal Indication(ICondition<TValue> condition, IIndication<Notice> indication)
            {
                this.condition = condition;

                this.indication = indication;
            }

            /// <inheritdoc/>
            public void Indicate(TValue value)
            {
                if (!condition.IsSatisfiedBy(value))
                {
                    return;
                }

                indication.Indicate(Notice.Instance);
            }
        }

        /// <summary>
        /// Detects <see cref="Notice"/> of <typeparamref name="TValue"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to detect.
        /// </typeparam>
        /// <param name="observation">
        /// <see cref="IObservation{TValue}"/> to detect.
        /// </param>
        /// <param name="condition">
        /// <see cref="ICondition{TValue}"/> to detect.
        /// </param>
        /// <returns>
        /// <see cref="IObservation{TValue}"/> for <see cref="Notice"/> detected.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="observation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static IObservation<Notice> Detect<TValue>(this IObservation<TValue> observation, ICondition<TValue> condition)
            where TValue : IValue
        {
            if (observation == null)
            {
                throw new ArgumentNullException(nameof(observation));
            }
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return new Observation<TValue>(observation, condition);
        }
        private sealed class Observation<TValue> :
            IObservation<Notice>
            where TValue : IValue
        {
            private readonly IObservation<TValue> observation;

            private readonly ICondition<TValue> condition;

            internal Observation(IObservation<TValue> observation, ICondition<TValue> condition)
            {
                this.observation = observation;

                this.condition = condition;
            }

            /// <inheritdoc/>
            public IInspection Observe(IIndication<Notice> indication)
            {
                if (indication == null)
                {
                    throw new ArgumentNullException(nameof(indication));
                }

                return observation.Observe(indication.Detect(condition));
            }
        }
    }
}

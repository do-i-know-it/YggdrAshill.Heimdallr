using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Explication
{
    public static class ConditionExtension
    {
        /// <summary>
        /// Detects <see cref="Notice"/> of <typeparamref name="TInformation"/>.
        /// </summary>
        /// <typeparam name="TInformation">
        /// Type of <see cref="IInformation"/> to detect.
        /// </typeparam>
        /// <param name="indication">
        /// <see cref="IIndication{TInformation}"/> for <see cref="Notice"/> detected.
        /// </param>
        /// <param name="condition">
        /// <see cref="ICondition{TInformation}"/> to detect.
        /// </param>
        /// <returns>
        /// <see cref="IIndication{TInformation}"/> to detect <typeparamref name="TInformation"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="indication"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static IIndication<TInformation> Detect<TInformation>(this IIndication<Notice> indication, ICondition<TInformation> condition)
            where TInformation : IInformation
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return new Indication<TInformation>(condition, indication);
        }
        private sealed class Indication<TInformation> :
            IIndication<TInformation>
            where TInformation : IInformation
        {
            private readonly IIndication<Notice> indication;

            private readonly ICondition<TInformation> condition;

            internal Indication(ICondition<TInformation> condition, IIndication<Notice> indication)
            {
                this.indication = indication;

                this.condition = condition;
            }

            /// <inheritdoc/>
            public void Indicate(TInformation information)
            {
                if (!condition.IsSatisfiedBy(information))
                {
                    return;
                }

                indication.Indicate(Notice.Instance);
            }
        }

        /// <summary>
        /// Detects <see cref="Notice"/> of <typeparamref name="TInformation"/>.
        /// </summary>
        /// <typeparam name="TInformation">
        /// Type of <see cref="IInformation"/> to detect.
        /// </typeparam>
        /// <param name="observation">
        /// <see cref="IObservation{TInformation}"/> to detect.
        /// </param>
        /// <param name="condition">
        /// <see cref="ICondition{TInformation}"/> to detect.
        /// </param>
        /// <returns>
        /// <see cref="IObservation{TInformation}"/> for <see cref="Notice"/> detected.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="observation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static IObservation<Notice> Detect<TInformation>(this IObservation<TInformation> observation, ICondition<TInformation> condition)
            where TInformation : IInformation
        {
            if (observation == null)
            {
                throw new ArgumentNullException(nameof(observation));
            }
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return new Observation<TInformation>(observation, condition);
        }
        private sealed class Observation<TInformation> :
            IObservation<Notice>
            where TInformation : IInformation
        {
            private readonly IObservation<TInformation> observation;

            private readonly ICondition<TInformation> condition;

            internal Observation(IObservation<TInformation> observation, ICondition<TInformation> condition)
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

        /// <summary>
        /// Inverts <see cref="ICondition{TInformation}"/>.
        /// </summary>
        /// <typeparam name="TInformation">
        /// Type of <see cref="IInformation"/> to detect.
        /// </typeparam>
        /// <param name="condition">
        /// <see cref="ICondition{TInformation}"/> to invert.
        /// </param>
        /// <returns>
        /// <see cref="ICondition{TInformation}"/> inverted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static ICondition<TInformation> Not<TInformation>(this ICondition<TInformation> condition)
            where TInformation : IInformation
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return new Invert<TInformation>(condition);
        }
        private sealed class Invert<TInformation> :
            ICondition<TInformation>
            where TInformation : IInformation
        {
            private readonly ICondition<TInformation> condition;

            internal Invert(ICondition<TInformation> condition)
            {
                this.condition = condition;
            }

            public bool IsSatisfiedBy(TInformation information)
            {
                return !condition.IsSatisfiedBy(information);
            }
        }

        /// <summary>
        /// Multiplies two instances of <see cref="ICondition{TInformation}"/>.
        /// </summary>
        /// <typeparam name="TInformation">
        /// Type of <see cref="IInformation"/> to detect.
        /// </typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>
        /// <see cref="ICondition{TInformation}"/> multiplied.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="left"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="right"/> is null.
        /// </exception>
        public static ICondition<TInformation> And<TInformation>(this ICondition<TInformation> left, ICondition<TInformation> right)
            where TInformation : IInformation
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            return new Multiply<TInformation>(left, right);
        }
        private sealed class Multiply<TInformation> :
            ICondition<TInformation>
            where TInformation : IInformation
        {
            private readonly ICondition<TInformation> left;

            private readonly ICondition<TInformation> right;

            internal Multiply(ICondition<TInformation> left, ICondition<TInformation> right)
            {
                this.left = left;

                this.right = right;
            }

            public bool IsSatisfiedBy(TInformation information)
            {
                return left.IsSatisfiedBy(information) && right.IsSatisfiedBy(information);
            }
        }

        /// <summary>
        /// Adds two instances of <see cref="ICondition{TInformation}"/>.
        /// </summary>
        /// <typeparam name="TInformation">
        /// Type of <see cref="IInformation"/> to detect.
        /// </typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>
        /// <see cref="ICondition{TInformation}"/> added.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="left"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="right"/> is null.
        /// </exception>
        public static ICondition<TInformation> Or<TInformation>(this ICondition<TInformation> left, ICondition<TInformation> right)
            where TInformation : IInformation
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            return new Add<TInformation>(left, right);
        }
        private sealed class Add<TInformation> :
            ICondition<TInformation>
            where TInformation : IInformation
        {
            private readonly ICondition<TInformation> left;

            private readonly ICondition<TInformation> right;

            internal Add(ICondition<TInformation> left, ICondition<TInformation> right)
            {
                this.left = left;

                this.right = right;
            }

            public bool IsSatisfiedBy(TInformation information)
            {
                return left.IsSatisfiedBy(information) || right.IsSatisfiedBy(information);
            }
        }
    }
}

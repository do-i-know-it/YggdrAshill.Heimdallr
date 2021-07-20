using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Explication
{
    /// <summary>
    /// Defines extensions for <see cref="ICondition{TValue}"/>.
    /// </summary>
    public static class ConditionExtension
    {
        /// <summary>
        /// Inverts <see cref="ICondition{TValue}"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to detect.
        /// </typeparam>
        /// <param name="condition">
        /// <see cref="ICondition{TValue}"/> to invert.
        /// </param>
        /// <returns>
        /// <see cref="ICondition{TValue}"/> inverted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static ICondition<TValue> Not<TValue>(this ICondition<TValue> condition)
            where TValue : IValue
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return new Invert<TValue>(condition);
        }
        private sealed class Invert<TValue> :
            ICondition<TValue>
            where TValue : IValue
        {
            private readonly ICondition<TValue> condition;

            internal Invert(ICondition<TValue> condition)
            {
                this.condition = condition;
            }

            /// <inheritdoc/>
            public bool IsSatisfiedBy(TValue value)
            {
                return !condition.IsSatisfiedBy(value);
            }
        }

        /// <summary>
        /// Multiplies two instances of <see cref="ICondition{TValue}"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to detect.
        /// </typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>
        /// <see cref="ICondition{TValue}"/> multiplied.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="left"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="right"/> is null.
        /// </exception>
        public static ICondition<TValue> And<TValue>(this ICondition<TValue> left, ICondition<TValue> right)
            where TValue : IValue
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            return new Multiply<TValue>(left, right);
        }
        private sealed class Multiply<TValue> :
            ICondition<TValue>
            where TValue : IValue
        {
            private readonly ICondition<TValue> left;

            private readonly ICondition<TValue> right;

            internal Multiply(ICondition<TValue> left, ICondition<TValue> right)
            {
                this.left = left;

                this.right = right;
            }

            /// <inheritdoc/>
            public bool IsSatisfiedBy(TValue value)
            {
                return left.IsSatisfiedBy(value) && right.IsSatisfiedBy(value);
            }
        }

        /// <summary>
        /// Adds two instances of <see cref="ICondition{TValue}"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to detect.
        /// </typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>
        /// <see cref="ICondition{TValue}"/> added.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="left"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="right"/> is null.
        /// </exception>
        public static ICondition<TValue> Or<TValue>(this ICondition<TValue> left, ICondition<TValue> right)
            where TValue : IValue
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            return new Add<TValue>(left, right);
        }
        private sealed class Add<TValue> :
            ICondition<TValue>
            where TValue : IValue
        {
            private readonly ICondition<TValue> left;

            private readonly ICondition<TValue> right;

            internal Add(ICondition<TValue> left, ICondition<TValue> right)
            {
                this.left = left;

                this.right = right;
            }

            /// <inheritdoc/>
            public bool IsSatisfiedBy(TValue value)
            {
                return left.IsSatisfiedBy(value) || right.IsSatisfiedBy(value);
            }
        }
    }
}

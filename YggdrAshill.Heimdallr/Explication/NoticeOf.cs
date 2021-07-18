using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr
{
    /// <summary>
    /// Defines implementations for <see cref="ICondition{TValue}"/>.
    /// </summary>
    public static class NoticeOf
    {
        /// <summary>
        /// Creates <see cref="ICondition{TValue}"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to detect.
        /// </typeparam>
        /// <param name="condition">
        /// <see cref="Func{T, TResult}"/> to detect <see cref="Notice"/> of <typeparamref name="TValue"/>.
        /// </param>
        /// <returns>
        /// <see cref="ICondition{TValue}"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static ICondition<TValue> Value<TValue>(Func<TValue, bool> condition)
            where TValue : IValue
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return new Condition<TValue>(condition);
        }
        private sealed class Condition<TValue> :
            ICondition<TValue>
            where TValue : IValue
        {
            private readonly Func<TValue, bool> condition;

            internal Condition(Func<TValue, bool> condition)
            {
                this.condition = condition;
            }

            /// <inheritdoc/>
            public bool IsSatisfiedBy(TValue value)
            {
                return condition.Invoke(value);
            }
        }

        /// <summary>
        /// Satisfied by all of <typeparamref name="TValue"/> even if <typeparamref name="TValue"/> is <see cref="null"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to detect.
        /// </typeparam>
        /// <returns>
        /// <see cref="ICondition{TValue}"/>.
        /// </returns>
        public static ICondition<TValue> All<TValue>()
            where TValue : IValue
        {
            return Value<TValue>(_ => true);
        }

        /// <summary>
        /// Satisfied by none of <typeparamref name="TValue"/> even if <typeparamref name="TValue"/> is <see cref="null"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to detect.
        /// </typeparam>
        /// <returns>
        /// <see cref="ICondition{TValue}"/>.
        /// </returns>
        public static ICondition<TValue> None<TValue>()
            where TValue : IValue
        {
            return Value<TValue>(_ => false);
        }
    }
}

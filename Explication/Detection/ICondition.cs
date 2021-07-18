using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Explication
{
    /// <summary>
    /// Detects <see cref="Notice"/> of <typeparamref name="TValue"/>.
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of <see cref="IValue"/> to detect.
    /// </typeparam>
    public interface ICondition<TValue>
        where TValue : IValue
    {
        /// <summary>
        /// Checks that <typeparamref name="TValue"/> is satisfied with condition.
        /// </summary>
        /// <param name="value">
        /// <typeparamref name="TValue"/> to detect.
        /// </param>
        /// <returns>
        /// True if condition is satisfied.
        /// </returns>
        bool IsSatisfiedBy(TValue value);
    }
}

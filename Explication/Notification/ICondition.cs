using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Explication
{
    /// <summary>
    /// Detects <see cref="Notice"/> of <typeparamref name="TInformation"/>.
    /// </summary>
    /// <typeparam name="TInformation">
    /// Type of <see cref="IInformation"/> to detect.
    /// </typeparam>
    public interface ICondition<TInformation>
        where TInformation : IInformation
    {
        /// <summary>
        /// Checks that <typeparamref name="TInformation"/> is satisfied with condition.
        /// </summary>
        /// <param name="information">
        /// <typeparamref name="TInformation"/> to detect.
        /// </param>
        /// <returns>
        /// True if condition is satisfied.
        /// </returns>
        bool IsSatisfiedBy(TInformation information);
    }
}

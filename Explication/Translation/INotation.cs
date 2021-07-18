using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Explication
{
    /// <summary>
    /// Converts <typeparamref name="TValue"/> to <see cref="Note"/>.
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of <see cref="IValue"/> to convert.
    /// </typeparam>
    public interface INotation<TValue>
        where TValue : IValue
    {
        /// <summary>
        /// Notates <typeparamref name="TValue"/>.
        /// </summary>
        /// <param name="value">
        /// <typeparamref name="TValue"/> to notate.
        /// </param>
        /// <returns>
        /// <see cref="Note"/> notated.
        /// </returns>
        Note Notate(TValue value);
    }
}

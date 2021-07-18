namespace YggdrAshill.Heimdallr.Elucidation
{
    /// <summary>
    /// Indicates <typeparamref name="TValue"/> received.
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of <see cref="IValue"/> to indicate.
    /// </typeparam>
    public interface IIndication<TValue>
        where TValue : IValue
    {
        /// <summary>
        /// Receives <typeparamref name="TValue"/>.
        /// </summary>
        /// <param name="value">
        /// <typeparamref name="TValue"/> received.
        /// </param>
        void Indicate(TValue value);
    }
}

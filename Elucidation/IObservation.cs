namespace YggdrAshill.Heimdallr.Elucidation
{
    /// <summary>
    /// Observes <typeparamref name="TValue"/>.
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of <see cref="IValue"/> to observe.
    /// </typeparam>
    public interface IObservation<TValue>
        where TValue : IValue
    {
        /// <summary>
        /// Sends <typeparamref name="TValue"/> to <see cref="IIndication{TValue}"/>.
        /// </summary>
        /// <param name="indication">
        /// <see cref="IIndication{TValue}"/> to receive <typeparamref name="TValue"/>.
        /// </param>
        /// <returns>
        /// <see cref="IInspection"/> to send <typeparamref name="TValue"/>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="indication"/> is null.
        /// </exception>
        IInspection Observe(IIndication<TValue> indication);
    }
}

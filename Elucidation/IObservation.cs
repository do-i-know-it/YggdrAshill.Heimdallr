namespace YggdrAshill.Heimdallr.Elucidation
{
    /// <summary>
    /// Observes <typeparamref name="TInformation"/>.
    /// </summary>
    /// <typeparam name="TInformation">
    /// Type of <see cref="IInformation"/> to observe.
    /// </typeparam>
    public interface IObservation<TInformation>
        where TInformation : IInformation
    {
        /// <summary>
        /// Sends <typeparamref name="TInformation"/> to <see cref="IIndication{TInformation}"/>.
        /// </summary>
        /// <param name="indication">
        /// <see cref="IIndication{TInformation}"/> to receive <typeparamref name="TInformation"/>.
        /// </param>
        /// <returns>
        /// <see cref="IInspection"/> to send <typeparamref name="TInformation"/>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="indication"/> is null.
        /// </exception>
        IInspection Observe(IIndication<TInformation> indication);
    }
}

namespace YggdrAshill.Heimdallr.Elucidation
{
    /// <summary>
    /// Indicates <typeparamref name="TInformation"/> received.
    /// </summary>
    /// <typeparam name="TInformation">
    /// Type of <see cref="IInformation"/> to indicate.
    /// </typeparam>
    public interface IIndication<TInformation>
        where TInformation : IInformation
    {
        /// <summary>
        /// Receives <typeparamref name="TInformation"/>.
        /// </summary>
        /// <param name="information">
        /// <typeparamref name="TInformation"/> received.
        /// </param>
        void Indicate(TInformation information);
    }
}

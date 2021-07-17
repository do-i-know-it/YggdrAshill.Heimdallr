using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Explication
{
    /// <summary>
    /// Converts <typeparamref name="TInformation"/> to <see cref="Note"/>.
    /// </summary>
    /// <typeparam name="TInformation">
    /// Type of <see cref="IInformation"/> to convert.
    /// </typeparam>
    public interface INotation<TInformation>
        where TInformation : IInformation
    {
        /// <summary>
        /// Notates <typeparamref name="TInformation"/>.
        /// </summary>
        /// <param name="information">
        /// <typeparamref name="TInformation"/> to notate.
        /// </param>
        /// <returns>
        /// <see cref="Note"/> notated.
        /// </returns>
        Note Notate(TInformation information);
    }
}

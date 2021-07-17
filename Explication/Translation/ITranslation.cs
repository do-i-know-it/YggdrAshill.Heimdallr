using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Explication
{
    /// <summary>
    /// Converts <typeparamref name="TInput"/> into <see cref="TOutput"/>.
    /// </summary>
    /// <typeparam name="TInput">
    /// Type of <see cref="IInformation"/> for input.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Type of <see cref="IInformation"/> for output.
    /// </typeparam>
    public interface ITranslation<TInput, TOutput>
        where TInput : IInformation
        where TOutput : IInformation
    {
        /// <summary>
        /// Translates <typeparamref name="TInput"/> into <see cref="TOutput"/>.
        /// </summary>
        /// <param name="information">
        /// <typeparamref name="TInput"/> to translate.
        /// </param>
        /// <returns>
        /// <typeparamref name="TOutput"/> translated.
        /// </returns>
        TOutput Translate(TInput information);
    }
}

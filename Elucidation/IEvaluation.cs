namespace YggdrAshill.Heimdallr.Elucidation
{
    /// <summary>
    /// Evaluates <typeparamref name="TInformation"/>.
    /// </summary>
    /// <typeparam name="TInformation">
    /// Type of <see cref="IInformation"/> to evaluate.
    /// </typeparam>
    public interface IEvaluation<TInformation>
        where TInformation : IInformation
    {
        /// <summary>
        /// Generates <typeparamref name="TInformation"/>.
        /// </summary>
        /// <returns>
        /// <typeparamref name="TInformation"/> generated.
        /// </returns>
        TInformation Evaluate();
    }
}

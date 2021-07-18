namespace YggdrAshill.Heimdallr.Elucidation
{
    /// <summary>
    /// Evaluates <typeparamref name="TValue"/>.
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of <see cref="IValue"/> to evaluate.
    /// </typeparam>
    public interface IEvaluation<TValue>
        where TValue : IValue
    {
        /// <summary>
        /// Generates <typeparamref name="TValue"/>.
        /// </summary>
        /// <returns>
        /// <typeparamref name="TValue"/> generated.
        /// </returns>
        TValue Evaluate();
    }
}

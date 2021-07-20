using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Explication
{
    /// <summary>
    /// Implementation of <see cref="IValue"/>.
    /// </summary>
    public sealed class Notice :
        IValue
    {
        /// <summary>
        /// Only <see cref="Notice"/> that exists.
        /// </summary>
        public static Notice Instance { get; } = new Notice();

        private Notice()
        {

        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{nameof(Notice)}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return 0;
        }
    }
}

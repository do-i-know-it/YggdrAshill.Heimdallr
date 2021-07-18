using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Explication
{
    /// <summary>
    /// Implementation of <see cref="IValue"/>.
    /// </summary>
    public sealed class Notice :
        IValue,
        IEquatable<Notice>
    {
        /// <summary>
        /// Only <see cref="Notice"/> that exists.
        /// </summary>
        public static Notice Instance { get; }
            = new Notice();

        private Notice()
        {

        }

        /// <inheritdoc/>
        public bool Equals(Notice other)
        {
            return ReferenceEquals(this, other);
        }
    }
}

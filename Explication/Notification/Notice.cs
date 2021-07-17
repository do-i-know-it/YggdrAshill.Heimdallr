using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Explication
{
    /// <summary>
    /// Implementation of <see cref="IInformation"/>.
    /// </summary>
    public sealed class Notice :
        IInformation,
        IEquatable<Notice>
    {
        #region Singleton

        /// <summary>
        /// <see cref="Notice"/> that only exists.
        /// </summary>
        public static Notice Instance { get; }
            = new Notice();

        private Notice()
        {

        }

        #endregion

        #region IEquatable

        /// <inheritdoc/>
        public bool Equals(Notice other)
        {
            return ReferenceEquals(this, other);
        }

        #endregion
    }
}

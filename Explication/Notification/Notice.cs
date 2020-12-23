using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Explication
{
    public sealed class Notice :
        IItem,
        IEquatable<Notice>
    {
        #region Singleton

        public static Notice Instance { get; }
            = new Notice();

        private Notice()
        {

        }

        #endregion

        #region IEquatable

        public bool Equals(Notice other)
        {
            return ReferenceEquals(this, other);
        }

        #endregion
    }
}

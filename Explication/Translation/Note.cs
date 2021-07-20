using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Explication
{
    /// <summary>
    /// Implementation of <see cref="IValue"/>.
    /// </summary>
    public struct Note :
        IValue,
        IEquatable<Note>
    {
        /// <summary>
        /// <see cref="None"/> of <see cref="Note"/>.
        /// </summary>
        public static Note None { get; } = new Note(string.Empty);

        private string content;
        /// <summary>
        /// <see cref="Content"/> of <see cref="Note"/>.
        /// </summary>
        public string Content
        {
            get
            {
                InitializeIfNeed();

                return content;
            }
        }

        private bool initialized;
        private void InitializeIfNeed()
        {
            if (initialized)
            {
                return;
            }

            content = string.Empty;

            initialized = true;
        }

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="content">
        /// <see cref="string"/> for <see cref="Content"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="content"/> is null.
        /// </exception>
        public Note(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            this.content = content;

            initialized = true;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return Content;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Content.GetHashCode();
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is Note value)
            {
                return Equals(value);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Equals(Note other)
        {
            return Content.Equals(other.Content);
        }

        /// <summary>
        /// Checks if one <see cref="Note"/> and another <see cref="Note"/> are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Note left, Note right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Checks if one <see cref="Note"/> and another <see cref="Note"/> are not equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Note left, Note right)
        {
            return !(left == right);
        }
    }
}

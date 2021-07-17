using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Explication
{
    /// <summary>
    /// Implementation of <see cref="IInformation"/>.
    /// </summary>
    public struct Note :
        IInformation,
        IEquatable<Note>
    {
        public static Note None { get; } = new Note(string.Empty);

        private string content;
        private bool initialized;
        private string Content
        {
            get
            {
                if (!initialized)
                {
                    content = string.Empty;

                    initialized = true;
                }

                return content;
            }
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

            if (obj is Note information)
            {
                return Equals(information);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Equals(Note other)
        {
            return Content.Equals(other.Content);
        }

        /// <summary>
        /// Converts explicitly <see cref="string"/> to <see cref="Note"/>.
        /// </summary>
        /// <param name="information">
        /// <see cref="string"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Note"/> converted.
        /// </returns>
        public static explicit operator Note(string information)
        {
            return new Note(information);
        }

        /// <summary>
        /// Converts explicitly <see cref="Note"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="information">
        /// <see cref="Note"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="string"/> converted.
        /// </returns>
        public static explicit operator string(Note information)
        {
            return information.Content;
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

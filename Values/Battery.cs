using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Values
{
    /// <summary>
    /// Implementation of <see cref="IValue"/> for battery.
    /// </summary>
    public struct Battery :
        IValue,
        IEquatable<Battery>
    {
        /// <summary>
        /// <see cref="Empty"/> of <see cref="Battery"/>.
        /// </summary>
        public const float Empty = 0.0f;

        /// <summary>
        /// <see cref="Full"/> of <see cref="Battery"/>.
        /// </summary>
        public const float Full = 1.0f;

        /// <summary>
        /// <see cref="Level"/> of <see cref="Battery"/>.
        /// If <see cref="Battery"/> is empty, <see cref="Level"/> is <see cref="Empty"/>.
        /// If <see cref="Battery"/> is ful, <see cref="Level"/> is <see cref="Full"/>.
        /// </summary>
        public float Level { get; }

        /// <summary>
        /// Construcs an instance.
        /// </summary>
        /// <param name="level">
        /// <see cref="float"/> for <see cref="Level"/>
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="level"/> is <see cref="float.NaN"/>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="level"/> is out of range between <see cref="Empty"/> and <see cref="Full"/>.
        /// </exception>
        public Battery(float level)
        {
            if (float.IsNaN(level))
            {
                throw new ArgumentException($"{nameof(level)} is NaN.");
            }

            if (level < Empty || Full < level)
            {
                throw new ArgumentOutOfRangeException(nameof(level));
            }

            Level = level;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Level}";
        }

        /// <inheritdoc/>
        public bool Equals(Battery other)
        {
            return Level.Equals(other.Level);
        }
    }
}

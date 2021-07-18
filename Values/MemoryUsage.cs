using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Values
{
    /// <summary>
    /// Implementation of <see cref="IValue"/> for memory usage.
    /// </summary>
    public struct MemoryUsage :
        IValue,
        IEquatable<MemoryUsage>
    {
        /// <summary>
        /// <see cref="UsedSize"/> in byte.
        /// </summary>
        public long UsedSize { get; }

        /// <summary>
        /// <see cref="UnusedSize"/> in byte.
        /// </summary>
        public long UnusedSize { get; }

        /// <summary>
        /// Construcs an instance.
        /// </summary>
        /// <param name="usedSize">
        /// <see cref="long"/> for <see cref="UsedSize"/> in byte.
        /// </param>
        /// <param name="unusedSize">
        /// <see cref="long"/> for <see cref="UnusedSize"/> in byte.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="usedSize"/> is negative.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="unusedSize"/> is negative.
        /// </exception>
        public MemoryUsage(long usedSize, long unusedSize)
        {
            if (usedSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(usedSize));
            }
            if (unusedSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(unusedSize));
            }

            UsedSize = usedSize;

            UnusedSize = unusedSize;
        }

        /// <summary>
        /// <see cref="TotalSize"/> of <see cref="MemoryUsage"/>.
        /// </summary>
        public long TotalSize
            => UsedSize + UnusedSize;

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{TotalSize}";
        }

        /// <inheritdoc/>
        public bool Equals(MemoryUsage other)
        {
            return UsedSize.Equals(other.UsedSize)
                && UnusedSize.Equals(other.UnusedSize);
        }
    }
}

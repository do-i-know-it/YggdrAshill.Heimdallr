using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr
{
    public struct MemoryUsage :
        IItem,
        IEquatable<MemoryUsage>
    {
        public long UsedSize { get; }

        public long UnusedSize { get; }

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

        public long TotalSize
            => UsedSize + UnusedSize;

        public bool Equals(MemoryUsage other)
        {
            return UsedSize.Equals(other.UsedSize)
                && UnusedSize.Equals(other.UnusedSize);
        }
    }
}

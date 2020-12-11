using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr
{
    public struct Battery :
        IItem,
        IEquatable<Battery>
    {
        public float Level { get; }

        public Battery(float level)
        {
            if (float.IsNaN(level))
            {
                throw new ArgumentException($"{nameof(level)} is NaN.");
            }

            const float Min = 0.0f;
            const float Max = 1.0f;
            if (level < Min || Max < level)
            {
                throw new ArgumentOutOfRangeException(nameof(level));
            }

            Level = level;
        }

        public bool Equals(Battery other)
        {
            return Level.Equals(other.Level);
        }
    }
}

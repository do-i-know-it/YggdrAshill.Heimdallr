using NUnit.Framework;
using YggdrAshill.Heimdallr.Items;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(MemoryUsage))]
    internal class MemoryUsageSpecification
    {
        [TestCase(0L, 1L)]
        [TestCase(1L, 0L)]
        [TestCase(0L, 0L)]
        public void UsedSizeAndUnusedSizeShouldBeEqualToTotalSize(long used, long unused)
        {
            var expected = used + unused;

            Assert.AreEqual(expected, new MemoryUsage(used, unused).TotalSize);
        }

        [Test]
        public void CannotBeGeneratedWithUsedSizeLowerThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var usage = new MemoryUsage(-1L, 0L);
            });
        }

        [Test]
        public void CannotBeGeneratedWithUnusedSizeLowerThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var usage = new MemoryUsage(0L, -1L);
            });
        }
    }
}

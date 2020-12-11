using NUnit.Framework;
using YggdrAshill.Heimdallr.Items;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Battery))]
    internal class BatterySpecification
    {
        [TestCase(1.0f)]
        [TestCase(0.5f)]
        [TestCase(0.0f)]
        public void ShouldSignifyLevel(float expected)
        {
            Assert.AreEqual(expected, new Battery(expected).Level);
        }

        [Test]
        public void CannotBeGeneratedWithNaNLevel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var battery = new Battery(float.NaN);
            });
        }

        [Test]
        public void CannotBeGeneratedWithLevelLowerThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var battery = new Battery(-0.1f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithLevelHigherThanOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var battery = new Battery(1.1f);
            });
        }
    }
}

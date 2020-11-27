using NUnit.Framework;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Indication<>))]
    internal class IndicationSpecification
    {
        [Test]
        public void ShouldExecuteActionWhenHasIndicated()
        {
            var expected = false;
            var indication = new Indication<Item>(_ =>
            {
                expected = true;
            });

            indication.Indicate(new Item());

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var indication = new Indication<Item>(null);
            });
        }
    }
}

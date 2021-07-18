using NUnit.Framework;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Indication))]
    internal class IndicationSpecification
    {
        [Test]
        public void ShouldExecuteActionWhenHasIndicated()
        {
            var expected = false;
            var indication = Indication.Of<Value>(value =>
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                expected = true;
            });

            indication.Indicate(new Value());

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var indication = Indication.Of<Value>(default);
            });
        }
    }
}

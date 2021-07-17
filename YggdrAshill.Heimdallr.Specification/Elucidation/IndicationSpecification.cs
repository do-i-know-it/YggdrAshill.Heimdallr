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
            var indication = Indication.Of<Information>(information =>
            {
                if (information == null)
                {
                    throw new ArgumentNullException(nameof(information));
                }

                expected = true;
            });

            indication.Indicate(new Information());

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var indication = Indication.Of<Information>(default);
            });
        }
    }
}

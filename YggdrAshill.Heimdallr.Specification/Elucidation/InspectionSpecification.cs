using NUnit.Framework;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Inspection))]
    internal class InspectionSpecification
    {
        [Test]
        public void ShouldExecuteActionWhenHasInspected()
        {
            var expected = false;
            var inspection =Inspection.Of(() =>
            {
                expected = true;
            });

            inspection.Inspect();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var inspection = Inspection.Of(null);
            });
        }
    }
}

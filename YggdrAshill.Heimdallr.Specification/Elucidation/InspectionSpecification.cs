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
            var inspection = new Inspection(() =>
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
                var inspection = new Inspection(null);
            });
        }
    }
}

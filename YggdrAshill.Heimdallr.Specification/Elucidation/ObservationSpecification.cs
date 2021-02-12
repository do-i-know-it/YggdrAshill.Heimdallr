using NUnit.Framework;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Observation<>))]
    internal class ObservationSpecification
    {
        private Indication<Item> indication;

        [SetUp]
        public void SetUp()
        {
            indication = new Indication<Item>();
        }

        [TearDown]
        public void TearDown()
        {
            indication = default;
        }

        [Test]
        public void ShouldExecuteFunctionWhenHasObserved()
        {
            var expected = false;
            var observation = new Observation<Item>(_ =>
            {
                expected = true;

                return new Inspection();
            });

            var inspection = observation.Observe(indication);

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldInspectAfterHasObserved()
        {
            var expected = false;
            var observation = new Observation<Item>(_ =>
            {
                return new Inspection(() =>
                {
                    expected = true;
                });
            });

            var inspection = observation.Observe(indication);

            inspection.Inspect();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var observation = new Observation<Item>(null);
            });
        }

        [Test]
        public void CannotObserveNull()
        {
            var observation = new Observation<Item>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var inspection = observation.Observe(null);
            });
        }
    }
}

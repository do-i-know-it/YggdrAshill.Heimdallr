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
        public void ShouldExecuteFunctionWhenHasSubscribed()
        {
            var expected = false;
            var observation = new Observation<Item>(_ =>
            {
                expected = true;

                return new Unsubscription();
            });

            var unsubscription = observation.Subscribe(indication);

            Assert.IsTrue(expected);

            unsubscription.Unsubscribe();
        }

        [Test]
        public void ShouldUnsubscribeAfterHasSubscribed()
        {
            var expected = false;
            var observation = new Observation<Item>(_ =>
            {
                return new Unsubscription(() =>
                {
                    expected = true;
                });
            });

            var unsubscription = observation.Subscribe(indication);

            unsubscription.Unsubscribe();

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
        public void CannotSubscribeNull()
        {
            var observation = new Observation<Item>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var unsubscription = observation.Subscribe(null);
            });
        }
    }
}

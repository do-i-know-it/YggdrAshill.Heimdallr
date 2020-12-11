using NUnit.Framework;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Inspection<>))]
    internal class InspectionSpecification
    {
        private Inspection<Item> inspection;

        [SetUp]
        public void SetUp()
        {
            inspection = new Inspection<Item>(() => new Item());
        }

        [TearDown]
        public void TearDown()
        {
            inspection.Unsubscribe();
            inspection = default;
        }

        [Test]
        public void ShouldSendItemToSubscribedAfterHasOriginated()
        {
            var expected = false;
            var indication = new Indication<Item>(item =>
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                expected = true;
            });

            var unsubscription = inspection.Subscribe(indication);

            var execution = inspection.Originate();

            execution.Execute();

            Assert.IsTrue(expected);

            unsubscription.Unsubscribe();
        }

        [Test]
        public void ShouldNotSendItemToUnsubscribedAfterHasOriginated()
        {
            var expected = false;
            var indication = new Indication<Item>(item =>
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                expected = true;
            });

            var unsubscription = inspection.Subscribe(indication);

            var execution = inspection.Originate();

            unsubscription.Unsubscribe();

            execution.Execute();

            Assert.IsFalse(expected);
        }

        [Test]
        public void ShouldNotSendItemAfterHasUnsubscribed()
        {
            var expected = false;
            var indication = new Indication<Item>(item =>
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                expected = true;
            });

            inspection.Subscribe(indication);

            var execution = inspection.Originate();

            inspection.Unsubscribe();

            execution.Execute();

            Assert.IsFalse(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var inspection = new Inspection<Item>(null);
            });
        }

        [Test]
        public void CannotSubscribeNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var unsubscription = inspection.Subscribe(null);
            });
        }
    }
}

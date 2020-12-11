using NUnit.Framework;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Source<>))]
    internal class SourceSpecification
    {
        private Source<Item> source;

        [SetUp]
        public void SetUp()
        {
            source = new Source<Item>(() => new Item());
        }

        [TearDown]
        public void TearDown()
        {
            source.Unsubscribe();
            source = default;
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

            var unsubscription = source.Subscribe(indication);

            var execution = source.Originate();

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

            var unsubscription = source.Subscribe(indication);

            var execution = source.Originate();

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

            source.Subscribe(indication);

            var execution = source.Originate();

            source.Unsubscribe();

            execution.Execute();

            Assert.IsFalse(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var source = new Source<Item>(null);
            });
        }

        [Test]
        public void CannotSubscribeNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var unsubscription = source.Subscribe(null);
            });
        }
    }
}

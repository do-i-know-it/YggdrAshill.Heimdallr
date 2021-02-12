using NUnit.Framework;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Publication<>))]
    internal class PublicationSpecification
    {
        private Publication<Item> publication;

        [SetUp]
        public void SetUp()
        {
            publication = new Publication<Item>();
        }

        [TearDown]
        public void TearDown()
        {
            publication.Unsubscribe();
            publication = null;
        }

        [Test]
        public void ShouldSendItemToSubscribedWhenHasIndicated()
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

            var unsubscription = publication.Subscribe(indication);

            publication.Indicate(new Item());

            Assert.IsTrue(expected);

            unsubscription.Unsubscribe();
        }

        [Test]
        public void ShouldNotSendItemToUnsubscribedWhenHasIndicated()
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

            var unsubscription = publication.Subscribe(indication);

            unsubscription.Unsubscribe();

            publication.Indicate(new Item());

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

            var unsubscription = publication.Subscribe(indication);

            publication.Unsubscribe();

            publication.Indicate(new Item());

            Assert.IsFalse(expected);
        }

        [Test]
        public void CannotSubscribeNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var unsubscription = publication.Subscribe(null);
            });
        }
    }
}

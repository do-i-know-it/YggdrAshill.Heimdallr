using NUnit.Framework;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Announcement<>))]
    internal class AnnouncementSpecification
    {
        private Announcement<Item> announcement;

        [SetUp]
        public void SetUp()
        {
            announcement = new Announcement<Item>();
        }

        [TearDown]
        public void TearDown()
        {
            announcement.Unsubscribe();
            announcement = null;
        }

        [Test]
        public void ShouldSendItemToSubscribedIndicationWhenHasIndicated()
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

            var unsubscription = announcement.Subscribe(indication);

            announcement.Indicate(new Item());

            Assert.IsTrue(expected);

            unsubscription.Unsubscribe();
        }

        [Test]
        public void ShouldNotSendItemToUnsubscribedIndicationWhenHasIndicated()
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

            var unsubscription = announcement.Subscribe(indication);

            unsubscription.Unsubscribe();

            announcement.Indicate(new Item());

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

            var unsubscription = announcement.Subscribe(indication);

            announcement.Unsubscribe();

            announcement.Indicate(new Item());

            Assert.IsFalse(expected);
        }

        [Test]
        public void CannotSubscribeNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var unsubscription = announcement.Subscribe(null);
            });
        }
    }
}

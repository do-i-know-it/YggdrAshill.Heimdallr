using NUnit.Framework;
using YggdrAshill.Heimdallr.Conversion;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Notator<>))]
    internal class NotatorSpecification : INotation<Item>
    {
        private Notator<Item> notator;

        private Announcement<Item> announcement;

        public Note Notate(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return new Note("");
        }

        [SetUp]
        public void SetUp()
        {
            announcement = new Announcement<Item>();

            notator = new Notator<Item>(announcement, this);
        }

        [TearDown]
        public void TearDown()
        {
            announcement.Unsubscribe();
            announcement = default;

            notator = default;
        }

        [Test]
        public void ShouldNotateItemWhenExecuted()
        {
            var expected = false;
            var indication = new Indication<Note>(item =>
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                expected = true;
            });

            var unsubscription = notator.Subscribe(indication);

            announcement.Indicate(new Item());

            Assert.IsTrue(expected);

            unsubscription.Unsubscribe();
        }

        [Test]
        public void CannotBeGeneratedWithNullPublication()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var notator = new Notator<Item>(null, this);
            });
        }

        [Test]
        public void CannotBeGeneratedWithNullNotation()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var notator = new Notator<Item>(announcement, null);
            });
        }

        [Test]
        public void CannotSubscribeNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var unsubscription = notator.Subscribe(null);
            });
        }
    }
}

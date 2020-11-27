using NUnit.Framework;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Publication<>))]
    internal class PublicationSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasSubscribed()
        {
            var expected = false;
            var publication = new Publication<Item>(_ =>
            {
                expected = true;

                return new Unsubscription();
            });

            var unsubscription = publication.Subscribe(new Indication<Item>());

            Assert.IsTrue(expected);

            unsubscription.Unsubscribe();
        }

        [Test]
        public void ShouldUnsubscribeAfterHasSubscribed()
        {
            var expected = false;
            var publication = new Publication<Item>(_ =>
            {
                return new Unsubscription(() =>
                {
                    expected = true;
                });
            });

            var unsubscription = publication.Subscribe(new Indication<Item>());

            unsubscription.Unsubscribe();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var publication = new Publication<Item>(null);
            });
        }

        [Test]
        public void CannotSubscribeNull()
        {
            var publication = new Publication<Item>(_ => new Unsubscription());

            Assert.Throws<ArgumentNullException>(() =>
            {
                var unsubscription = publication.Subscribe(null);
            });
        }
    }
}

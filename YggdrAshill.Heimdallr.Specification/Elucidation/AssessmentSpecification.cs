using NUnit.Framework;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Assessment<>))]
    internal class AssessmentSpecification
    {
        private Assessment<Item> assessment;

        [SetUp]
        public void SetUp()
        {
            assessment = new Assessment<Item>(() => new Item());
        }

        [TearDown]
        public void TearDown()
        {
            assessment.Unsubscribe();
            assessment = default;
        }

        [Test]
        public void ShouldSendItemToSubscribedAfterHasExamined()
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

            var unsubscription = assessment.Subscribe(indication);

            var inspection = assessment.Examine();

            inspection.Inspect();

            Assert.IsTrue(expected);

            unsubscription.Unsubscribe();
        }

        [Test]
        public void ShouldNotSendItemToUnsubscribedAfterHasExamined()
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

            var unsubscription = assessment.Subscribe(indication);

            var inspection = assessment.Examine();

            unsubscription.Unsubscribe();

            inspection.Inspect();

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

            assessment.Subscribe(indication);

            var inspection = assessment.Examine();

            assessment.Unsubscribe();

            inspection.Inspect();

            Assert.IsFalse(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var assessment = new Assessment<Item>(null);
            });
        }

        [Test]
        public void CannotSubscribeNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var unsubscription = assessment.Subscribe(null);
            });
        }
    }
}

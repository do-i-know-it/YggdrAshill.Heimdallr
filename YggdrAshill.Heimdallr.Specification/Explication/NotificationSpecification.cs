using NUnit.Framework;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Notification<>))]
    internal class NotificationSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasNotified()
        {
            var expected = false;
            var notification = new Notification<Item>(item =>
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                return expected = true;
            });

            notification.Notify(new Item());

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var notification = new Notification<Item>(null);
            });
        }
    }
}

using NUnit.Framework;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Unsubscription))]
    internal class UnsubscriptionSpecification
    {
        [Test]
        public void ShouldExecuteActionWhenHasUnsubscribed()
        {
            var expected = false;
            var unsubscription = new Unsubscription(() =>
            {
                expected = true;
            });

            unsubscription.Unsubscribe();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var unsubscription = new Unsubscription(null);
            });
        }
    }
}

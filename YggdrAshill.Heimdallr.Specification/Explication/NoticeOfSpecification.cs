using NUnit.Framework;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(NoticeOf))]
    internal class NoticeOfSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasBeenSatisfied()
        {
            var expected = false;
            var condition = NoticeOf.Value<Value>(value =>
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                return expected = true;
            });

            condition.IsSatisfiedBy(new Value());

            Assert.IsTrue(expected);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldBeSatisfiedByValue(bool expected)
        {
            var condition = NoticeOf.Value<Value>(value =>
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                return expected;
            });

            var detected = condition.IsSatisfiedBy(new Value());

            Assert.AreEqual(expected, detected);
        }

        [Test]
        public void ShouldBeAlwaysSatisfied()
        {
            Assert.IsTrue(NoticeOf.All<Value>().IsSatisfiedBy(null));
        }

        [Test]
        public void ShouldBeNeverSatisfied()
        {
            Assert.IsFalse(NoticeOf.None<Value>().IsSatisfiedBy(null));
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var generation = NoticeOf.Value<Value>(default);
            });
        }
    }
}

using NUnit.Framework;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(ConditionExtension))]
    internal class ConditionExtensionSpecification
    {
        private readonly Value value = new Value();

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldBeInverted(bool expected)
        {
            var condition = new NoticeOfValue(expected);
            Assert.AreEqual(!condition.IsSatisfiedBy(value), condition.Not().IsSatisfiedBy(value));
        }

        [TestCase(true, true, true)]
        [TestCase(true, false, true)]
        [TestCase(false, true, true)]
        [TestCase(false, false, false)]
        public void ShouldBeAdded(bool one, bool another, bool expected)
        {
            Assert.AreEqual(expected, new NoticeOfValue(one).Or(new NoticeOfValue(another)).IsSatisfiedBy(value));
        }

        [TestCase(true, true, true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, false)]
        [TestCase(false, false, false)]
        public void ShouldBeMultiplied(bool one, bool another, bool expected)
        {
            Assert.AreEqual(expected, new NoticeOfValue(one).And(new NoticeOfValue(another)).IsSatisfiedBy(value));
        }

        [Test]
        public void CannotBeInvertedByNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var condition = default(ICondition<Value>).Not();
            });
        }

        [Test]
        public void CannotBeAddedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var condition = default(ICondition<Value>).Or(new NoticeOfValue(false));
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var condition = new NoticeOfValue(false).Or(default);
            });
        }

        [Test]
        public void CannotBeMultipliedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var condition = default(ICondition<Value>).And(new NoticeOfValue(false));
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var condition = new NoticeOfValue(false).And(default);
            });
        }
    }
}

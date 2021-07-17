using NUnit.Framework;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Condition<>))]
    internal class ConditionSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasCheckedCondition()
        {
            var expected = false;
            var condition = new Condition<Information>(item =>
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                return expected = true;
            });

            condition.IsSatisfiedBy(new Information());

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var condition = new Condition<Information>(null);
            });
        }
    }
}

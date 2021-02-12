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
            var condition = new Condition<Item>(item =>
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                return expected = true;
            });

            condition.IsSatisfied(new Item());

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var condition = new Condition<Item>(null);
            });
        }
    }
}

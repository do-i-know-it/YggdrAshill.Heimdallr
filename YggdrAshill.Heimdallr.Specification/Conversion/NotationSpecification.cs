using NUnit.Framework;
using YggdrAshill.Heimdallr.Conversion;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Notation<>))]
    internal class NotationSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasNotated()
        {
            var expected = false;
            var notation = new Notation<Item>(item =>
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                expected = true;

                return new Note("");
            });

            notation.Notate(new Item());

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var notation = new Notation<Item>(null);
            });
        }
    }
}

using NUnit.Framework;
using YggdrAshill.Heimdallr.Explication;
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
            var notation = new Notation<Information>(item =>
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                expected = true;

                return Note.None;
            });

            notation.Notate(new Information());

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var notation = new Notation<Information>(null);
            });
        }
    }
}

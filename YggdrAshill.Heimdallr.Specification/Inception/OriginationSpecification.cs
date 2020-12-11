using NUnit.Framework;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Origination))]
    internal class OriginationSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasOriginated()
        {
            var expected = false;
            var origination = new Origination(() =>
            {
                expected = true;

                return new Execution();
            });

            var execution = origination.Originate();

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldExecuteAfterHasOriginated()
        {
            var expected = false;
            var origination = new Origination(() =>
            {
                return new Execution(() =>
                {
                    expected = true;
                });
            });

            var execution = origination.Originate();

            execution.Execute();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var origination = new Origination(null);
            });
        }
    }
}

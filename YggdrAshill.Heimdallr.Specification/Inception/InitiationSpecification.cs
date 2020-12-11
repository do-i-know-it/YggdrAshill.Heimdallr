using NUnit.Framework;
using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Inception;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Initiation<>))]
    internal class InitiationSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasInitiated()
        {
            var expected = false;
            var initiation = new Initiation<Item>((_) =>
            {
                expected = true;

                return new Execution();
            });

            var execution = initiation.Initiate(new Indication<Item>());

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldExecuteAfterHasInitiated()
        {
            var expected = false;
            var initiation = new Initiation<Item>((_) =>
            {
                return new Execution(() =>
                {
                    expected = true;
                });
            });

            var execution = initiation.Initiate(new Indication<Item>());

            execution.Execute();

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldSendItemWhenHasExecuted()
        {
            var initiation = new Initiation<Item>(() =>
            {
                return new Item();
            });

            var expected = false;
            var indication = new Indication<Item>(item =>
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                expected = true;
            });

            var execution = initiation.Initiate(indication);

            execution.Execute();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var initiation = new Initiation<Item>((Func<IIndication<Item>, IExecution>)null);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var initiation = new Initiation<Item>((Func<Item>)null);
            });
        }

        [Test]
        public void CannotInceptNull()
        {
            var initiation = new Initiation<Item>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var execution = initiation.Initiate(null);
            });
        }
    }
}

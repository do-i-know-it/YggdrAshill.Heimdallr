using NUnit.Framework;
using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Incepction;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Source<>))]
    internal class SourceSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasIncepted()
        {
            var expected = false;
            var source = new Source<Item>((_) =>
            {
                expected = true;

                return new Execution();
            });

            var execution = source.Incept(new Indication<Item>());

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldExecuteAfterHasIncepted()
        {
            var expected = false;
            var source = new Source<Item>((_) =>
            {
                return new Execution(() =>
                {
                    expected = true;
                });
            });

            var execution = source.Incept(new Indication<Item>());

            execution.Execute();

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldSendItemWhenHasExecuted()
        {
            var source = new Source<Item>(() =>
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

            var execution = source.Incept(indication);

            execution.Execute();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var source = new Source<Item>((Func<IIndication<Item>, IExecution>)null);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var source = new Source<Item>((Func<Item>)null);
            });
        }

        [Test]
        public void CannotInceptNull()
        {
            var source = new Source<Item>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var execution = source.Incept(null);
            });
        }
    }
}

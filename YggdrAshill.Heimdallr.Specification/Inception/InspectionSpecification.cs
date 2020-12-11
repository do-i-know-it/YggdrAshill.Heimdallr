using NUnit.Framework;
using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Inception;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Inspection<>))]
    internal class InspectionSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasActivated()
        {
            var expected = false;
            var initiation = new Inspection<Item>((_) =>
            {
                expected = true;

                return new Execution();
            });

            var execution = initiation.Activate(new Indication<Item>());

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldExecuteAfterHasActivated()
        {
            var expected = false;
            var initiation = new Inspection<Item>((_) =>
            {
                return new Execution(() =>
                {
                    expected = true;
                });
            });

            var execution = initiation.Activate(new Indication<Item>());

            execution.Execute();

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldSendItemWhenHasExecuted()
        {
            var initiation = new Inspection<Item>(() =>
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

            var execution = initiation.Activate(indication);

            execution.Execute();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var initiation = new Inspection<Item>((Func<IIndication<Item>, IExecution>)null);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var initiation = new Inspection<Item>((Func<Item>)null);
            });
        }

        [Test]
        public void CannotActivateWithNull()
        {
            var initiation = new Inspection<Item>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var execution = initiation.Activate(null);
            });
        }
    }
}

using NUnit.Framework;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Observation<>))]
    internal class ObservationSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasExecuted()
        {
            var expected = false;
            var observation = new Observation<Item>(_ =>
            {
                expected = true;

                return new Execution();
            });

            var execution = observation.Activate(new Indication<Item>());

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldExecuteAfterHasActivated()
        {
            var expected = false;
            var observation = new Observation<Item>(_ =>
            {
                return new Execution(() =>
                {
                    expected = true;
                });
            });

            var execution = observation.Activate(new Indication<Item>());

            execution.Execute();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var observation = new Observation<Item>(null);
            });
        }

        [Test]
        public void CannotActivateNull()
        {
            var observation = new Observation<Item>(_ => new Execution());

            Assert.Throws<ArgumentNullException>(() =>
            {
                var execution = observation.Activate(null);
            });
        }
    }
}

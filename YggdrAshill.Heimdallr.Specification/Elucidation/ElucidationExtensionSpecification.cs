using NUnit.Framework;
using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(ElucidationExtension))]
    internal class ElucidationExtensionSpecification
    {
        private Value expected;

        private IObservation<Value> observation;

        [SetUp]
        public void SetUp()
        {
            expected = new Value();

            observation = Observation.Of(expected);
        }

        [Test]
        public void ShouldConvertEvaluationIntoObservation()
        {
            var indicated = default(Value);
            var inspection = observation.Observe(value =>
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                indicated = value;
            });

            inspection.Inspect();

            Assert.AreEqual(expected, indicated);
        }

        [Test]
        public void CannotObserveWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var inspection = default(IObservation<Value>).Observe(_ => { });
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var inspection = observation.Observe(default(Action<Value>));
            });
        }
    }
}

using NUnit.Framework;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Observation))]
    internal class ObservationSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasInspected()
        {
            var expected = false;
            var evaluation = Observation.Of(() =>
            {
                expected = true;

                return new Value();
            });

            var inspection = evaluation.Observe(Indication.None<Value>());

            inspection.Inspect();

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldSendValueWhenHasInspected()
        {
            var expected = new Value();
            var evaluation = Observation.Of(() =>
            {
                return expected;
            });

            var indicated = default(Value);
            var indication = Indication.Of<Value>(value =>
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                indicated = value;
            });

            var inspection = evaluation.Observe(indication);

            inspection.Inspect();

            Assert.AreEqual(expected, indicated);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var evaluation = Observation.Of(default(Func<Value>));
            });
        }

        [Test]
        public void CannotObserveNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var evaluation = Observation.Of(new Value()).Observe(default);
            });
        }
    }
}

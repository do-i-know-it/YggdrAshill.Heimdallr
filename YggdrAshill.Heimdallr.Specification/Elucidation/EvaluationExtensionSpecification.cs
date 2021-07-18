using NUnit.Framework;
using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(EvaluationExtension))]
    internal class EvaluationExtensionSpecification :
        IEvaluation<Value>,
        IIndication<Value>
    {
        private Value expected;
        public Value Evaluate()
        {
            return expected;
        }

        private Value indicated;
        public void Indicate(Value value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            indicated = value;
        }

        private IEvaluation<Value> evaluation;

        private IIndication<Value> indication;

        [SetUp]
        public void SetUp()
        {
            expected = new Value();
            evaluation = this;

            indicated = null;
            indication = this;
        }

        [Test]
        public void ShouldConvertEvaluationIntoObservation()
        {
            var observation = evaluation.Convert();

            var inspection = observation.Observe(indication);

            inspection.Inspect();

            Assert.AreEqual(expected, indicated);
        }

        [Test]
        public void CannotConvertWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var observation = default(IEvaluation<Value>).Convert();
            });
        }

        [Test]
        public void CannotObserveWithNull()
        {
            var observation = evaluation.Convert();
            Assert.Throws<ArgumentNullException>(() =>
            {
                var inspection = observation.Observe(default(IIndication<Value>));
            });
        }
    }
}

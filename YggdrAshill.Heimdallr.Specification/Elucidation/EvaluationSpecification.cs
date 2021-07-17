using NUnit.Framework;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Evaluation))]
    internal class EvaluationSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasEvaluated()
        {
            var expected = false;
            var evaluation = Evaluation.Of(() =>
           {
               expected = true;

               return new Information();
           });

            evaluation.Evaluate();

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldEvaluateInformation()
        {
            var expected = new Information();
            var evaluation = Evaluation.Of(() =>
            {
                return expected;
            });

            var evaluated = evaluation.Evaluate();

            Assert.AreEqual(expected, evaluated);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var evaluation = Evaluation.Of(default(Func<Information>));
            });
        }
    }
}

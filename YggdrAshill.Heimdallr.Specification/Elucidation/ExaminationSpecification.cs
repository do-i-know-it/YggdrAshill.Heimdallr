using NUnit.Framework;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Examination))]
    internal class ExaminationSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasExamined()
        {
            var expected = false;
            var examination = new Examination(() =>
            {
                expected = true;

                return new Inspection();
            });

            var inspection = examination.Examine();

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldExecuteAfterHasExamined()
        {
            var expected = false;
            var examination = new Examination(() =>
            {
                return new Inspection(() =>
                {
                    expected = true;
                });
            });

            var inspection = examination.Examine();

            inspection.Inspect();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var examination = new Examination(null);
            });
        }
    }
}

using NUnit.Framework;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Translation<,>))]
    internal class TranslationSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasTranslated()
        {
            var expected = false;
            var translation = new Translation<InputInformation, OutputInformation>(item =>
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                expected = true;

                return new OutputInformation();
            });

            translation.Translate(new InputInformation());

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = new Translation<InputInformation, OutputInformation>(null);
            });
        }
    }
}

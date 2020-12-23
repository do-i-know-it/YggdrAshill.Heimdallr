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
            var translation = new Translation<InputItem, OutputItem>(item =>
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                expected = true;

                return new OutputItem();
            });

            translation.Translate(new InputItem());

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = new Translation<InputItem, OutputItem>(null);
            });
        }
    }
}

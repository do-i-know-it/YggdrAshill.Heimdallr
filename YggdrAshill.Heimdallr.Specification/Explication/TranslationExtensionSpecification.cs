using NUnit.Framework;
using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(TranslationExtension))]
    internal class TranslationExtensionSpecification
    {
        private FakeObservation<Value> observation;

        private FakeIndication<Note> indication;

        [SetUp]
        public void SetUp()
        {
            observation = new FakeObservation<Value>(new Value());

            indication = new FakeIndication<Note>(Note.None);
        }

        [TestCase("test")]
        [TestCase("")]
        public void IndicationShouldTranslateValue(string expected)
        {
            var notation = new NoteOfValue(expected);

            indication.Translate(notation).Indicate(new Value());

            Assert.AreEqual(expected, indication.Indicated.Content);
        }

        [TestCase("test")]
        [TestCase("")]
        public void ObservationShouldTranslateValue(string expected)
        {
            var notation = new NoteOfValue(expected);

            var inspection = observation.Translate(notation).Observe(indication);

            inspection.Inspect();

            Assert.AreEqual(expected, indication.Indicated.Content);
        }

        [Test]
        public void IndicationCannotTranslateValueWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translated = default(IIndication<Note>).Translate(new NoteOfValue());
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var translated = indication.Translate(default(INotation<Value>));
            });
        }

        [Test]
        public void ObservationCannotTranslateValueWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translated = default(IObservation<Value>).Translate(new NoteOfValue());
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var translated = observation.Translate(default(INotation<Value>));
            });
        }
    }
}

using NUnit.Framework;
using YggdrAshill.Heimdallr.Explication;
using System;
using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(TranslationExtension))]
    internal class TranslationExtensionSpecification :
        IInspection,
        IObservation<Value>,
        IIndication<Note>,
        INotation<Value>
    {
        private IIndication<Value> toInspect;

        private Value evaluated;
        public IInspection Observe(IIndication<Value> indication)
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            toInspect = indication;

            return this;
        }
        public void Inspect()
        {
            toInspect.Indicate(evaluated);
        }

        private Note indicated;
        public void Indicate(Note value)
        {
            indicated = value;
        }

        private string expected;
        public Note Notate(Value value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return new Note(expected);
        }

        private IObservation<Value> observation;

        private INotation<Value> notation;

        private IIndication<Note> indication;

        [SetUp]
        public void SetUp()
        {
            evaluated = new Value();
            observation = this;

            expected = null;
            notation = this;

            indicated = Note.None;
            indication = this;
        }

        [TestCase("test")]
        [TestCase("")]
        public void IndicationShouldTranslateValue(string expected)
        {
            this.expected = expected;

            indication.Translate(notation).Indicate(new Value());

            Assert.AreEqual(expected, indicated.Content);
        }

        [TestCase("test")]
        [TestCase("")]
        public void ObservationShouldTranslateValue(string expected)
        {
            this.expected = expected;

            var inspection = observation.Translate(notation).Observe(indication);

            inspection.Inspect();

            Assert.AreEqual(expected, indicated.Content);
        }

        [Test]
        public void IndicationCannotTranslateValueWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translated = default(IIndication<Note>).Translate(notation);
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
                var translated = default(IObservation<Value>).Translate(notation);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var translated = observation.Translate(default(INotation<Value>));
            });
        }
    }
}

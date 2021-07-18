using NUnit.Framework;
using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(ExplicationExtension))]
    internal class ExplicationExtensionSpecification
    {
        private IObservation<Value> observation;

        [SetUp]
        public void SetUp()
        {
            observation
                = Evaluation.Of(() =>
                {
                    return new Value();
                })
                .Convert();
        }

        [TestCase("test")]
        [TestCase("")]
        public void IndicationShouldTranslateValue(string expected)
        {
            var indicated = Note.None;
            var indication = Indication.Of<Note>(value =>
            {
                indicated = value;
            });

            indication
                .Translate<Value>(value =>
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException(nameof(value));
                    }

                    return new Note(expected);
                })
                .Indicate(new Value());

            Assert.AreEqual(expected, indicated.Content);
        }

        [TestCase("test")]
        [TestCase("")]
        public void ObservationShouldTranslateValue(string expected)
        {
            var indicated = Note.None;
            var indication = Indication.Of<Note>(value =>
            {
                indicated = value;
            });

            var inspection
                = observation
                .Translate(value =>
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException(nameof(value));
                    }

                    return new Note(expected);
                })
                .Observe(indication);

            inspection.Inspect();

            Assert.AreEqual(expected, indicated.Content);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IndicationShouldDetectValue(bool expected)
        {
            var indicated = false;
            var indication = Indication.Of<Notice>(value =>
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                indicated = true;
            });

            indication
                .Detect<Value>(value =>
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException(nameof(value));
                    }

                    return expected;
                })
                .Indicate(new Value());

            Assert.AreEqual(expected, indicated);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ObservationShouldDetectValue(bool expected)
        {
            var indicated = false;
            var inspection
                = observation
                .Detect(value =>
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException(nameof(value));
                    }

                    return expected;
                })
                .Observe(value =>
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException(nameof(value));
                    }

                    indicated = true;
                });

            inspection.Inspect();

            Assert.AreEqual(expected, indicated);
        }

        [Test]
        public void IndicationCannotTranslateValueWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translated = default(IIndication<Note>).Translate<Value>(_ => Note.None);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var translated = Indication.None<Note>().Translate(default(Func<Value, Note>));
            });
        }

        [Test]
        public void ObservationCannotTranslateValueWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translated = default(IObservation<Value>).Translate(_ => Note.None);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var translated = observation.Translate(default);
            });
        }

        [Test]
        public void IndicationCannotDetectValueWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = default(IIndication<Notice>).Detect(NoticeOf.None<Value>());
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = Indication.None<Notice>().Detect(default(ICondition<Value>));
            });
        }

        [Test]
        public void ObservationCannotDetectValueWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = default(IObservation<Value>).Detect(NoticeOf.None<Value>());
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = observation.Detect(default);
            });
        }
    }
}

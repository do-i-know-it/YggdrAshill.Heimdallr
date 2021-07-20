using NUnit.Framework;
using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(DetectionExtension))]
    internal class DetectionExtensionSpecification
    {
        private FakeObservation<Value> observation;

        private IndicateNotice indication;

        [SetUp]
        public void SetUp()
        {
            observation = new FakeObservation<Value>(new Value());

            indication = new IndicateNotice();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IndicationShouldDetectValue(bool expected)
        {
            var condition = new NoticeOfValue(expected);

            indication.Detect(condition).Indicate(new Value());

            Assert.AreEqual(expected, indication.Indicated);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ObservationShouldDetectValue(bool expected)
        {
            var condition = new NoticeOfValue(expected);

            var inspection = observation.Detect(condition).Observe(indication);

            inspection.Inspect();

            Assert.AreEqual(expected, indication.Indicated);
        }

        [Test]
        public void IndicationCannotDetectValueWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = default(IIndication<Notice>).Detect(new NoticeOfValue());
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = indication.Detect(default(ICondition<Value>));
            });
        }

        [Test]
        public void ObservationCannotDetectValueWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = default(IObservation<Value>).Detect(new NoticeOfValue());
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = observation.Detect(default(ICondition<Value>));
            });
        }
    }
}

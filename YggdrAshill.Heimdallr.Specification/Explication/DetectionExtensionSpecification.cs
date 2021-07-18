﻿using NUnit.Framework;
using YggdrAshill.Heimdallr.Explication;
using System;
using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(DetectionExtension))]
    internal class DetectionExtensionSpecification :
        IEvaluation<Value>,
        IIndication<Notice>,
        ICondition<Value>
    {
        private Value evaluated;
        public Value Evaluate()
        {
            return evaluated;
        }

        private bool indicated;
        public void Indicate(Notice value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            indicated = true;
        }

        private bool expected;
        public bool IsSatisfiedBy(Value value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return expected;
        }

        private IObservation<Value> observation;

        private ICondition<Value> condition;

        private IIndication<Notice> indication;

        [SetUp]
        public void SetUp()
        {
            evaluated = new Value();
            observation = this.Convert();

            expected = false;
            condition = this;

            indicated = false;
            indication = this;
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IndicationShouldDetectValue(bool expected)
        {
            this.expected = expected;

            indication.Detect(condition).Indicate(new Value());

            Assert.AreEqual(expected, indicated);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ObservationShouldDetectValue(bool expected)
        {
            this.expected = expected;

            var inspection = observation.Detect(condition).Observe(indication);

            inspection.Inspect();

            Assert.AreEqual(expected, indicated);
        }

        [Test]
        public void IndicationCannotDetectValueWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = default(IIndication<Notice>).Detect(condition);
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
                var detected = default(IObservation<Value>).Detect(condition);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = observation.Detect(default(ICondition<Value>));
            });
        }
    }
}

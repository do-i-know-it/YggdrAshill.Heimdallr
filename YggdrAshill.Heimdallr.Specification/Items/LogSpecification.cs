using NUnit.Framework;
using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Log))]
    [TestFixture(TestOf = typeof(LogExtension))]
    internal class LogSpecification :
        IIndication<Log>
    {
        private Log recorded;

        public void Indicate(Log information)
        {
            recorded = information;
        }

        private IIndication<Log> indication;

        [SetUp]
        public void SetUp()
        {
            recorded = default;

            indication = this;
        }

        [TestCase(Log.Severity.Fatal, "message")]
        [TestCase(Log.Severity.None, "")]
        public void ShouldRecordMessage(Log.Severity level, string message)
        {
            indication.Record(level, message);

            Assert.AreEqual(level, recorded.Level);
            Assert.AreEqual(message, recorded.Message);
        }

        [TestCase(Log.Severity.Fatal, "message")]
        [TestCase(Log.Severity.None, "")]
        public void ShouldRecordException(Log.Severity level, string message)
        {
            var expected = new Exception(message);

            indication.Record(level, expected);

            Assert.AreEqual(level, recorded.Level);
            Assert.AreEqual(expected.ToString(), recorded.Message);

            Console.WriteLine(recorded.Message);
        }
    }
}

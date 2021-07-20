using NUnit.Framework;
using YggdrAshill.Heimdallr.Historization;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Log))]
    [TestFixture(TestOf = typeof(LogExtension))]
    internal class HistorizationSpecification
    {
        private FakeIndication<Log> indication;

        [SetUp]
        public void SetUp()
        {
            indication = new FakeIndication<Log>(new Log());
        }

        [TestCase(Log.Severity.Fatal, "message")]
        [TestCase(Log.Severity.None, "")]
        public void ShouldRecordMessage(Log.Severity level, string message)
        {
            indication.Record(level, message);

            Assert.AreEqual(level, indication.Indicated.Level);
            Assert.AreEqual(message, indication.Indicated.Message);
        }

        [TestCase(Log.Severity.Fatal, "message")]
        [TestCase(Log.Severity.None, "")]
        public void ShouldRecordException(Log.Severity level, string message)
        {
            var expected = new Exception(message);

            indication.Record(level, expected);

            Assert.AreEqual(level, indication.Indicated.Level);
            Assert.AreEqual(expected.ToString(), indication.Indicated.Message);

            Console.WriteLine(indication.Indicated.Message);
        }
    }
}

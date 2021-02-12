using NUnit.Framework;
using YggdrAshill.Heimdallr.Historization;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(HistorizationExtension))]
    internal class HistorizationExtensionSpecification
    {
        [TestCase("message")]
        [TestCase("")]
        public void ShouldLogMessage(string expected)
        {
            var consumed = default(Log);
            var indication = new Indication<Log>(signal =>
            {
                consumed = signal;
            });

            indication.Log(SeverityLevel.Information, expected);

            Assert.AreEqual(expected, consumed.Message);
        }

        [Test]
        public void ShouldLogException()
        {
            var consumed = default(Log);
            var indication = new Indication<Log>(signal =>
            {
                consumed = signal;
            });

            var expected = new Exception();

            indication.Log(SeverityLevel.Information, expected);

            Assert.AreEqual(expected.ToString(), consumed.Message);
        }

        [TestCase(SeverityLevel.Fatal)]
        [TestCase(SeverityLevel.None)]
        public void ShouldLogSeverityLevel(SeverityLevel expected)
        {
            var consumed = default(Log);
            var indication = new Indication<Log>(signal =>
            {
                consumed = signal;
            });

            indication.Log(expected, "");

            Assert.AreEqual(expected, consumed.Severity);
        }
    }
}

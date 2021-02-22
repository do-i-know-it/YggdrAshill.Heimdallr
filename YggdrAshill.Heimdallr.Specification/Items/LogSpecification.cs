using NUnit.Framework;
using YggdrAshill.Heimdallr.Items;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(ItemExtension))]
    internal class LogSpecification
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

            indication.Log(Log.Severity.Information, expected);

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

            indication.Log(Log.Severity.Information, expected);

            Assert.AreEqual(expected.ToString(), consumed.Message);
        }

        [TestCase(Log.Severity.Fatal)]
        [TestCase(Log.Severity.None)]
        public void ShouldLogLevel(Log.Severity expected)
        {
            var consumed = default(Log);
            var indication = new Indication<Log>(signal =>
            {
                consumed = signal;
            });

            indication.Log(expected, "");

            Assert.AreEqual(expected, consumed.Level);
        }
    }
}

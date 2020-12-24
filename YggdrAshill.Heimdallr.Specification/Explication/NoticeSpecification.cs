using NUnit.Framework;
using YggdrAshill.Heimdallr.Explication;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(Notice))]
    internal class NoticeSpecification
    {
        [Test]
        public void ShouldBeEqualToAnyInstance()
        {
            Assert.AreEqual(Notice.Instance, Notice.Instance);
        }

        [Test]
        public void CannotBeEqualToNull()
        {
            Assert.AreNotEqual(Notice.Instance, null);
        }
    }
}

using NUnit.Framework;
using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(ExplicationExtension))]
    internal class ExplicationExtensionSpecification :
        ITranslation<InputItem, OutputItem>,
        INotation<Item>,
        INotification<Item>
    {
        #region ITranslation

        public OutputItem Translate(InputItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return new OutputItem();
        }

        #endregion

        #region INotation

        public Note Notate(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return new Note("");
        }

        #endregion

        #region INotification

        private bool expected;

        public bool Notify(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return expected;
        }

        #endregion

        [Test]
        public void ShouldTranslateItem()
        {
            var publication = new Publication<InputItem>();
            var translation = publication.Translate(this);

            var expected = false;
            var indication = new Indication<OutputItem>(item =>
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                expected = true;
            });

            var unsubscription = translation.Subscribe(indication);

            publication.Indicate(new InputItem());

            Assert.IsTrue(expected);

            unsubscription.Unsubscribe();
        }

        [Test]
        public void ShouldNotateItem()
        {
            var publication = new Publication<Item>();
            var notation = publication.Notate(this);

            var expected = false;
            var indication = new Indication<Note>(item =>
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                expected = true;
            });

            var unsubscription = notation.Subscribe(indication);

            publication.Indicate(new Item());

            Assert.IsTrue(expected);

            unsubscription.Unsubscribe();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldNotifyItem(bool expected)
        {
            this.expected = expected;

            var publication = new Publication<Item>();
            var notification = publication.Notify(this);

            var notified = false;
            var indication = new Indication<Notice>(item =>
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                notified = true;
            });

            var unsubscription = notification.Subscribe(indication);

            publication.Indicate(new Item());

            Assert.AreEqual(expected, notified);

            unsubscription.Unsubscribe();
        }

        [Test]
        public void CannotTranslateWithNullSubscription()
        {
            var subscription = default(ISubscription<InputItem>);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var notation = subscription.Translate(this);
            });
        }

        [Test]
        public void CannotTranslateWithNullTranslation()
        {
            var publication = new Publication<InputItem>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = publication.Translate((ITranslation<InputItem, OutputItem>)null);
            });
        }

        [Test]
        public void CannotNotateWithNullSubscription()
        {
            var subscription = default(ISubscription<Item>);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var notation = subscription.Notate(this);
            });
        }

        [Test]
        public void CannotNotateWithNullNotation()
        {
            var publication = new Publication<Item>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var notation = publication.Notate((INotation<Item>)null);
            });
        }

        [Test]
        public void CannotNotifyWithNullSubscription()
        {
            var subscription = default(ISubscription<Item>);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var notification = subscription.Notify(this);
            });
        }

        [Test]
        public void CannotNotifyWithNullNotification()
        {
            var publication = new Publication<Item>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var notification = publication.Notify(null);
            });
        }
    }
}

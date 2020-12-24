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
        public Note Notate(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return new Note("");
        }

        public OutputItem Translate(InputItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return new OutputItem();
        }

        private bool expected;

        public bool Notify(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return expected;
        }

        [Test]
        public void ShouldTranslateItemWhenHasIndicated()
        {
            var announcement = new Announcement<InputItem>();
            var translator = announcement.Translate(this);

            var expected = false;
            var indication = new Indication<OutputItem>(item =>
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                expected = true;
            });

            var unsubscription = translator.Subscribe(indication);

            announcement.Indicate(new InputItem());

            Assert.IsTrue(expected);

            unsubscription.Unsubscribe();
        }

        [Test]
        public void ShouldNotateItemWhenHasIndicated()
        {
            var announcement = new Announcement<Item>();
            var notator = announcement.Notate(this);

            var expected = false;
            var indication = new Indication<Note>(item =>
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                expected = true;
            });

            var unsubscription = notator.Subscribe(indication);

            announcement.Indicate(new Item());

            Assert.IsTrue(expected);

            unsubscription.Unsubscribe();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldNotifyItemWhenHasIndicated(bool expected)
        {
            this.expected = expected;

            var announcement = new Announcement<Item>();
            var notifier = announcement.Notify(this);

            var received = false;
            var indication = new Indication<Notice>(item =>
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                received = true;
            });

            var unsubscription = notifier.Subscribe(indication);

            announcement.Indicate(new Item());

            Assert.AreEqual(expected, received);

            unsubscription.Unsubscribe();
        }

        [Test]
        public void NullObservationCannotTranslate()
        {
            var observation = default(IObservation<InputItem>);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var notator = observation.Translate(this);
            });
        }

        [Test]
        public void CannotTranslateNull()
        {
            var announcement = new Announcement<InputItem>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var translator = announcement.Translate((ITranslation<InputItem, OutputItem>)null);
            });
        }

        [Test]
        public void TranslatorCannotSubscribeNull()
        {
            var announcement = new Announcement<InputItem>();
            var translator = announcement.Translate(this);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var unsubscription = translator.Subscribe(null);
            });
        }

        [Test]
        public void NullObservationCannotNotate()
        {
            var observation = default(IObservation<Item>);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var notator = observation.Notate(this);
            });
        }

        [Test]
        public void CannotNotateNull()
        {
            var announcement = new Announcement<Item>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var notator = announcement.Notate(null);
            });
        }

        [Test]
        public void NotatorCannotSubscribeNull()
        {
            var announcement = new Announcement<Item>();
            var notator = announcement.Notate(this);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var unsubscription = notator.Subscribe(null);
            });
        }

        [Test]
        public void NullObservationCannotNotify()
        {
            var observation = default(IObservation<Item>);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var notifier = observation.Notify(this);
            });
        }

        [Test]
        public void CannotNotifyNull()
        {
            var announcement = new Announcement<Item>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var notifier = announcement.Notify(null);
            });
        }

        [Test]
        public void NotifierCannotSubscribeNull()
        {
            var announcement = new Announcement<Item>();
            var notifier = announcement.Notify(this);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var unsubscription = notifier.Subscribe(null);
            });
        }
    }
}

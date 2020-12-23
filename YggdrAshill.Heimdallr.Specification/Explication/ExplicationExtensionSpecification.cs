using NUnit.Framework;
using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(ExplicationExtension))]
    internal class ExplicationExtensionSpecification :
        ITranslation<InputItem, OutputItem>,
        INotation<Item>
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

        [Test]
        public void ShouldTranslateItemWhenIndicated()
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
        public void ShouldNotateItemWhenIndicated()
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
    }
}

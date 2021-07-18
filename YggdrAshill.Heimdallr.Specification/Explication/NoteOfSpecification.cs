using NUnit.Framework;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr.Specification
{
    [TestFixture(TestOf = typeof(NoteOf))]
    internal class NoteOfSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasNotated()
        {
            var expected = false;
            var notation = NoteOf.Value<Value>(value =>
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                expected = true;

                return Note.None;
            });

            var note = notation.Notate(new Value());

            Assert.IsTrue(expected);
        }

        [TestCase("test")]
        [TestCase("")]
        public void ShouldNotateValue(string expected)
        {
            var notation = NoteOf.Value<Value>(value =>
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                return new Note(expected);
            });

            var note = notation.Notate(new Value());

            Assert.AreEqual(expected, note.Content);
        }

        [TestCase("test")]
        [TestCase("")]
        public void ShouldNotateNote(string content)
        {
            var expected = new Note(content);
            var notation = NoteOf.Note(content =>
            {
                if (content == null)
                {
                    throw new ArgumentNullException(nameof(content));
                }

                return content;
            });

            var note = notation.Notate(expected);

            Assert.AreEqual(expected, note);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var notation = NoteOf.Value<Value>(default);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var notation = NoteOf.Note(default);
            });
        }
    }
}

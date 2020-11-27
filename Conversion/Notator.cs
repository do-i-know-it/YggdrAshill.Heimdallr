using YggdrAshill.Heimdallr.Inspection;
using System;

namespace YggdrAshill.Heimdallr.Conversion
{
    public sealed class Notator<TItem> :
        IPublication<Note>
        where TItem : IItem
    {
        private readonly IPublication<TItem> publication;

        private readonly INotation<TItem> notation;

        public Notator(IPublication<TItem> publication, INotation<TItem> notation)
        {
            if (publication == null)
            {
                throw new ArgumentNullException(nameof(publication));
            }
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            this.publication = publication;

            this.notation = notation;
        }

        public IUnsubscription Subscribe(IIndication<Note> indication)
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return publication.Subscribe(new Notate(indication, notation));
        }

        private sealed class Notate :
            IIndication<TItem>
        {
            private readonly IIndication<Note> indication;

            private readonly INotation<TItem> notation;

            public Notate(IIndication<Note> indication, INotation<TItem> notation)
            {
                this.indication = indication;

                this.notation = notation;
            }

            public void Indicate(TItem item)
            {
                var note = notation.Notate(item);

                indication.Indicate(note);
            }
        }
    }
}

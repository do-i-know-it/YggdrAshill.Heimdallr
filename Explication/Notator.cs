using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Explication
{
    public sealed class Notator<TItem> :
        IObservation<Note>
        where TItem : IItem
    {
        private readonly IObservation<TItem> observation;

        private readonly INotation<TItem> notation;

        public Notator(IObservation<TItem> observation, INotation<TItem> notation)
        {
            if (observation == null)
            {
                throw new ArgumentNullException(nameof(observation));
            }
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            this.observation = observation;

            this.notation = notation;
        }

        public IUnsubscription Subscribe(IIndication<Note> indication)
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return observation.Subscribe(new Notate(indication, notation));
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

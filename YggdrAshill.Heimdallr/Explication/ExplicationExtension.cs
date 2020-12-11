using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr
{
    public static class ExplicationExtension
    {
        public static IObservation<Note> Notate<TItem>(this IObservation<TItem> observation, INotation<TItem> notation)
            where TItem : IItem
        {
            if (observation == null)
            {
                throw new ArgumentNullException(nameof(observation));
            }
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return new Notator<TItem>(observation, notation);
        }

        public static IObservation<Note> Notate<TItem>(this IObservation<TItem> observation, Func<TItem, Note> onNotated)
            where TItem : IItem
        {
            if (observation == null)
            {
                throw new ArgumentNullException(nameof(observation));
            }
            if (onNotated == null)
            {
                throw new ArgumentNullException(nameof(onNotated));
            }

            var notation = new Notation<TItem>(onNotated);

            return observation.Notate(notation);
        }
    }
}

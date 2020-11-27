using YggdrAshill.Heimdallr.Inspection;
using YggdrAshill.Heimdallr.Conversion;
using System;

namespace YggdrAshill.Heimdallr
{
    public static class ConversionExtension
    {
        public static IPublication<Note> Notate<TItem>(this IPublication<TItem> publication, INotation<TItem> notation)
            where TItem : IItem
        {
            if (publication == null)
            {
                throw new ArgumentNullException(nameof(publication));
            }
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return new Notator<TItem>(publication, notation);
        }

        public static IPublication<Note> Notate<TItem>(this IPublication<TItem> publication, Func<TItem, Note> onNotated)
            where TItem : IItem
        {
            if (publication == null)
            {
                throw new ArgumentNullException(nameof(publication));
            }
            if (onNotated == null)
            {
                throw new ArgumentNullException(nameof(onNotated));
            }

            var notation = new Notation<TItem>(onNotated);

            return publication.Notate(notation);
        }
    }
}

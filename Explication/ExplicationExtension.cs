using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr.Explication
{
    public static class ExplicationExtension
    {
        #region Translation

        public static ISubscription<TOutput> Translate<TInput, TOutput>(this ISubscription<TInput> subscription, ITranslation<TInput, TOutput> translation)
            where TInput : IItem
            where TOutput : IItem
        {
            if (subscription == null)
            {
                throw new ArgumentNullException(nameof(subscription));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new Translator<TInput, TOutput>(subscription, translation);
        }

        public static IIndication<TInput> Translated<TInput, TOutput>(this IIndication<TOutput> indication, ITranslation<TInput, TOutput> translation)
            where TInput : IItem
            where TOutput : IItem
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new Translate<TInput, TOutput>(indication, translation);
        }

        #endregion

        #region Notation

        public static ISubscription<Note> Notate<TItem>(this ISubscription<TItem> subscription, INotation<TItem> notation)
            where TItem : IItem
        {
            if (subscription == null)
            {
                throw new ArgumentNullException(nameof(subscription));
            }
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return subscription.Translate(new Notate<TItem>(notation));
        }

        public static IIndication<TItem> Notated<TItem>(this IIndication<Note> indication, INotation<TItem> notation)
            where TItem : IItem
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return indication.Translated(new Notate<TItem>(notation));
        }

        #endregion

        #region Notification

        public static ISubscription<Notice> Notify<TItem>(this ISubscription<TItem> subscription, INotification<TItem> notification)
            where TItem : IItem
        {
            if (subscription == null)
            {
                throw new ArgumentNullException(nameof(subscription));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new Notifier<TItem>(subscription, notification);
        }

        public static IIndication<TItem> Notified<TItem>(this IIndication<Notice> indication, INotification<TItem> notification)
            where TItem : IItem
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new Notify<TItem>(indication, notification);
        }

        #endregion
    }
}

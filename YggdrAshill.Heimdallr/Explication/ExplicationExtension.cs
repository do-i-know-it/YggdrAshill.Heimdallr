using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr
{
    public static class ExplicationExtension
    {
        #region Translation

        public static ISubscription<TOutput> Translate<TInput, TOutput>(this ISubscription<TInput> subscription, Func<TInput, TOutput> translation)
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

            return subscription.Translate(new Translation<TInput, TOutput>(translation));
        }

        public static IIndication<TInput> Translated<TInput, TOutput>(this IIndication<TOutput> indication, Func<TInput, TOutput> translation)
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

            return indication.Translated(new Translation<TInput, TOutput>(translation));
        }

        #endregion

        #region Notation

        public static ISubscription<Note> Notate<TItem>(this ISubscription<TItem> subscription, Func<TItem, Note> notation)
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

            return subscription.Notate(new Notation<TItem>(notation));
        }

        public static IIndication<TItem> Notated<TItem>(this IIndication<Note> indication, Func<TItem, Note> notation)
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

            return indication.Notated(new Notation<TItem>(notation));
        }

        #endregion

        #region INotification

        public static ISubscription<Notice> Notify<TItem>(this ISubscription<TItem> subscription, Func<TItem, bool> notification)
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

            return subscription.Notify(new Notification<TItem>(notification));
        }

        public static IIndication<TItem> Notified<TItem>(this IIndication<Notice> indication, Func<TItem, bool> notification)
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

            return indication.Notified(new Notification<TItem>(notification));
        }

        public static IUnsubscription Subscribe(this ISubscription<Notice> subscription, Action onIndicated)
        {
            if (subscription == null)
            {
                throw new ArgumentNullException(nameof(subscription));
            }
            if (onIndicated == null)
            {
                throw new ArgumentNullException(nameof(onIndicated));
            }

            return subscription.Subscribe(item =>
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                onIndicated.Invoke();
            });
        }

        #endregion
    }
}

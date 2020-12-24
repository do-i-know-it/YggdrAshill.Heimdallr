using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr
{
    public static class ExplicationExtension
    {
        #region Translation

        public static IObservation<TOutput> Translate<TInput, TOutput>(this IObservation<TInput> observation, Func<TInput, TOutput> translation)
            where TInput : IItem
            where TOutput : IItem
        {
            if (observation == null)
            {
                throw new ArgumentNullException(nameof(observation));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return observation.Translate(new Translation<TInput, TOutput>(translation));
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

        public static IObservation<Note> Notate<TItem>(this IObservation<TItem> observation, Func<TItem, Note> notation)
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

            return observation.Notate(new Notation<TItem>(notation));
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

        public static IObservation<Notice> Notify<TItem>(this IObservation<TItem> observation, Func<TItem, bool> notification)
            where TItem : IItem
        {
            if (observation == null)
            {
                throw new ArgumentNullException(nameof(observation));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return observation.Notify(new Notification<TItem>(notification));
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

        public static IUnsubscription Subscribe(this IObservation<Notice> observation, Action onIndicated)
        {
            if (observation == null)
            {
                throw new ArgumentNullException(nameof(observation));
            }
            if (onIndicated == null)
            {
                throw new ArgumentNullException(nameof(onIndicated));
            }

            return observation.Subscribe(item =>
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

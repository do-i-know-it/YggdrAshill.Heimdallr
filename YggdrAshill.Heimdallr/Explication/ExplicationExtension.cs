using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr
{
    public static class ExplicationExtension
    {
        #region Translate

        public static IObservation<TOutput> Translate<TInput, TOutput>(this IObservation<TInput> observation, Func<TInput, TOutput> translation)
            where TInput : IInformation
            where TOutput : IInformation
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

        public static IIndication<TInput> Translate<TInput, TOutput>(this IIndication<TOutput> indication, Func<TInput, TOutput> translation)
            where TInput : IInformation
            where TOutput : IInformation
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return indication.Translate(new Translation<TInput, TOutput>(translation));
        }

        #endregion

        #region INotification

        public static IObservation<Notice> Detect<TInformation>(this IObservation<TInformation> observation, Func<TInformation, bool> condition)
            where TInformation : IInformation
        {
            if (observation == null)
            {
                throw new ArgumentNullException(nameof(observation));
            }
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return observation.Detect(new Condition<TInformation>(condition));
        }

        public static IIndication<TInformation> Detect<TInformation>(this IIndication<Notice> indication, Func<TInformation, bool> condition)
            where TInformation : IInformation
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return indication.Detect(new Condition<TInformation>(condition));
        }

        public static IInspection Observe(this IObservation<Notice> observation, Action indication)
        {
            if (observation == null)
            {
                throw new ArgumentNullException(nameof(observation));
            }
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            return observation.Observe(information =>
            {
                if (information == null)
                {
                    throw new ArgumentNullException(nameof(information));
                }

                indication.Invoke();
            });
        }

        #endregion
    }
}

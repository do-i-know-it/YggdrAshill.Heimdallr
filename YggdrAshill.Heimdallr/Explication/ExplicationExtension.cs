using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr
{
    public static class ExplicationExtension
    {
        #region Translate

        /// <summary>
        /// Translates <typeparamref name="TValue"/> into <see cref="Note"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to notate.
        /// </typeparam>
        /// <param name="indication">
        /// <see cref="IIndication{TValue}"/> to receive <see cref="Note"/>.
        /// </param>
        /// <param name="notation">
        /// <see cref="Func{T, TResult}"/> to translate <typeparamref name="TValue"/> into <see cref="Note"/>.
        /// </param>
        /// <returns>
        /// <see cref="IIndication{TValue}"/> to receive <typeparamref name="TValue"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="indication"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notation"/> is null.
        /// </exception>
        public static IIndication<TValue> Translate<TValue>(this IIndication<Note> indication, Func<TValue, Note> notation)
            where TValue : IValue
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return indication.Translate(NoteOf.Value(notation));
        }

        /// <summary>
        /// Translates <typeparamref name="TValue"/> into <see cref="Note"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to notate.
        /// </typeparam>
        /// <param name="observation">
        /// <see cref="IObservation{TValue}"/> to send <typeparamref name="TValue"/>.
        /// </param>
        /// <param name="notation">
        /// <see cref="Func{T, TResult}"/> to translate <typeparamref name="TValue"/> into <see cref="Note"/>.
        /// </param>
        /// <returns>
        /// <see cref="IObservation{TValue}"/> to send <see cref="Note"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="observation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notation"/> is null.
        /// </exception>
        public static IObservation<Note> Translate<TValue>(this IObservation<TValue> observation, Func<TValue, Note> notation)
            where TValue : IValue
        {
            if (observation == null)
            {
                throw new ArgumentNullException(nameof(observation));
            }
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return observation.Translate(NoteOf.Value(notation));
        }

        #endregion

        #region Detect

        /// <summary>
        /// Detects <see cref="Notice"/> of <typeparamref name="TValue"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to detect.
        /// </typeparam>
        /// <param name="indication">
        /// <see cref="IIndication{TValue}"/> for <see cref="Notice"/> detected.
        /// </param>
        /// <param name="condition">
        /// <see cref="Func{T, TResult}"/> to detect <see cref="Notice"/> of <typeparamref name="TValue"/>.
        /// </param>
        /// <returns>
        /// <see cref="IIndication{TValue}"/> to detect <typeparamref name="TValue"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="indication"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static IIndication<TValue> Detect<TValue>(this IIndication<Notice> indication, Func<TValue, bool> condition)
            where TValue : IValue
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return indication.Detect(NoticeOf.Value(condition));
        }

        /// <summary>
        /// Detects <see cref="Notice"/> of <typeparamref name="TValue"/>.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of <see cref="IValue"/> to detect.
        /// </typeparam>
        /// <param name="observation">
        /// <see cref="IObservation{TValue}"/> to detect.
        /// </param>
        /// <param name="condition">
        /// <see cref="Func{T, TResult}"/> to detect <see cref="Notice"/> of <typeparamref name="TValue"/>.
        /// </param>
        /// <returns>
        /// <see cref="IObservation{TValue}"/> for <see cref="Notice"/> detected.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="observation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static IObservation<Notice> Detect<TValue>(this IObservation<TValue> observation, Func<TValue, bool> condition)
            where TValue : IValue
        {
            if (observation == null)
            {
                throw new ArgumentNullException(nameof(observation));
            }
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return observation.Detect(NoticeOf.Value(condition));
        }

        /// <summary>
        /// Sends <see cref="Notice"/> to <see cref="Action"/>.
        /// </summary>
        /// <param name="observation">
        /// <see cref="IObservation{TValue}"/> to send <see cref="Notice"/>.
        /// </param>
        /// <param name="indication">
        /// <see cref="Action"/> to execute when this has received <see cref="Notice"/>.
        /// </param>
        /// <returns>
        /// <see cref="IInspection"/> inspect.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="observation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="indication"/> is null.
        /// </exception>
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

            return observation.Observe(value =>
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                indication.Invoke();
            });
        }

        #endregion
    }
}

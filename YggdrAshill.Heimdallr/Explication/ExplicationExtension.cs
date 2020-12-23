﻿using YggdrAshill.Heimdallr.Elucidation;
using YggdrAshill.Heimdallr.Explication;
using System;

namespace YggdrAshill.Heimdallr
{
    public static class ExplicationExtension
    {
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
    }
}

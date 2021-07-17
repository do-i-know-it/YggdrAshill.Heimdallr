using YggdrAshill.Heimdallr.Elucidation;
using System;

namespace YggdrAshill.Heimdallr
{
    /// <summary>
    /// Implementation of <see cref="IInspection"/>.
    /// </summary>
    public sealed class Inspection :
        IInspection
    {
        /// <summary>
        /// Executes <see cref="Action"/>.
        /// </summary>
        /// <param name="inspection">
        /// <see cref="Action"/> to inspect.
        /// </param>
        /// <returns>
        /// <see cref="Inspection"/> created.
        /// </returns>
        public static Inspection Of(Action inspection)
        {
            if (inspection == null)
            {
                throw new ArgumentNullException(nameof(inspection));
            }

            return new Inspection(inspection);
        }

        /// <summary>
        /// Executes none.
        /// </summary>
        public static Inspection None { get; } = Of(() => { });

        private readonly Action onInspected;

        private Inspection(Action onInspected)
        {
            this.onInspected = onInspected;
        }

        /// <inheritdoc/>
        public void Inspect()
        {
            onInspected.Invoke();
        }
    }
}

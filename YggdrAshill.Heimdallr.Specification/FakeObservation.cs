using System;
using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Specification
{
    internal class FakeObservation<TValue> :
        IObservation<TValue>,
        IInspection
        where TValue : IValue
    {
        internal TValue Expected { get; }

        private IIndication<TValue> indication;

        internal FakeObservation(TValue expected)
        {
            Expected = expected;
        }

        public void Inspect()
        {
            if (indication == null)
            {
                throw new InvalidOperationException(nameof(indication));
            }

            indication.Indicate(Expected);
        }

        public IInspection Observe(IIndication<TValue> indication)
        {
            if (indication == null)
            {
                throw new ArgumentNullException(nameof(indication));
            }

            this.indication = indication;

            return this;
        }
    }
}

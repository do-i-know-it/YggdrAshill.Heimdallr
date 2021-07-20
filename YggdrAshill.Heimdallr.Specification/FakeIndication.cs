using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Specification
{
    internal class FakeIndication<TValue> :
        IIndication<TValue>
        where TValue : IValue
    {
        internal TValue Indicated { get; private set; }

        internal FakeIndication(TValue initialized)
        {
            Indicated = initialized;
        }

        public void Indicate(TValue value)
        {
            Indicated = value;
        }
    }
}

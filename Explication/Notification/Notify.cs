using YggdrAshill.Heimdallr.Elucidation;

namespace YggdrAshill.Heimdallr.Explication
{
    internal sealed class Notify<TItem> :
        IIndication<TItem>
        where TItem : IItem
    {
        private readonly IIndication<Notice> indication;

        private readonly ICondition<TItem> condition;

        internal Notify(IIndication<Notice> indication, ICondition<TItem> condition)
        {
            this.indication = indication;

            this.condition = condition;
        }

        public void Indicate(TItem item)
        {
            if (!condition.IsSatisfied(item))
            {
                return;
            }

            indication.Indicate(Notice.Instance);
        }
    }
}

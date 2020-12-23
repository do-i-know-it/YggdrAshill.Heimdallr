namespace YggdrAshill.Heimdallr.Elucidation
{
    public interface IAssessment<TItem> :
        IObservation<TItem>,
        IUnsubscription,
        IExamination
        where TItem : IItem
    {

    }
}

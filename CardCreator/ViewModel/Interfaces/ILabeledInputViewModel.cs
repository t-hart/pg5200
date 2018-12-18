namespace CardCreator.ViewModel.Interfaces
{
    public interface ILabeledInputViewModel<T>
    {
        string Label { get; }
        T Value { get; set; }
    }
}

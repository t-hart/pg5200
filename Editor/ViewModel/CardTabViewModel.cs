using Editor.Interfaces;

namespace Editor.ViewModel
{
    class CardTabViewModel : ITab<IFieldable>
    {
        public IFieldable ContentViewModel { get; set; }
    }
}

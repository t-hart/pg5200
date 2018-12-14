using Editor.Interfaces;
using GalaSoft.MvvmLight;
using JetBrains.Annotations;

namespace Editor.ViewModel
{
    public class MoveTabViewModel : ViewModelBase, ITab<IMove>
    {
        public IMove ContentViewModel { get; set; }

        [NotNull] public CounterInputViewModel Damage { get; }

        public MoveTabViewModel([NotNull] IMove move)
        {
            ContentViewModel = move;
            Damage = new CounterInputViewModel(ContentViewModel.Damage);
        }
    }
}

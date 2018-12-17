using Editor.Interfaces;
using GalaSoft.MvvmLight;
using IO;
using JetBrains.Annotations;

namespace Editor.ViewModel
{
    public class MoveTabViewModel : TabViewModel<IMove>
    {
        protected override void ForceUpdate()
        {
            RaisePropertyChanged("");
            Damage.RaisePropertyChanged("");
        }

        [NotNull] public CounterInputViewModel Damage { get; }

        public MoveTabViewModel([NotNull] IMove move, IStorageService jsonService) : base(jsonService)
        {
            ContentViewModel = move;
            Damage = new CounterInputViewModel(ContentViewModel.Damage);
        }
    }
}

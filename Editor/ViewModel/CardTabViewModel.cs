using System.Windows.Input;
using Editor.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JetBrains.Annotations;
using Microsoft.Win32;
using Type = Editor.CardProperties.Type;

namespace Editor.ViewModel
{
    public class CardTabViewModel : ViewModelBase, ITab<IPokemon>
    {
        public IPokemon ContentViewModel { get; set; }

        [NotNull] public CounterInputViewModel HP { get; }
        [NotNull] public CounterInputViewModel Level { get; }
        [NotNull] public ToggleableComboBoxViewModel<Type> Weakness { get; }
        [NotNull] public ToggleableComboBoxViewModel<Type> Resistance { get; }
        [NotNull] public ComboBoxViewModel<Type> Type { get; }

        [NotNull]
        public string ImagePath
        {
            get => ContentViewModel.ImagePath;
            set
            {
                if (ImagePath == value) { return; }
                ContentViewModel.ImagePath = value;
                RaisePropertyChanged("");
            }
        }

        public RelayCommand OpenCommand { get; }

        private void OpenFile()
        {
            //var dialog = new OpenFileDialog { InitialDirectory = "." };
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                ImagePath = dialog.FileName;
            }
        }

        public CardTabViewModel([NotNull] IPokemon contentViewModel)
        {
            ContentViewModel = contentViewModel;
            HP = new CounterInputViewModel(ContentViewModel.HP);
            Level = new CounterInputViewModel(ContentViewModel.Level);
            Weakness = new ToggleableComboBoxViewModel<Type>(ContentViewModel.Weakness);
            Resistance = new ToggleableComboBoxViewModel<Type>(ContentViewModel.Resistance);
            Type = new ComboBoxViewModel<Type>(ContentViewModel.Type);

            OpenCommand = new RelayCommand(OpenFile);
        }

    }
}

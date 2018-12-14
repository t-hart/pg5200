using System.Windows;
using Editor.CardProperties;
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
        [NotNull] public ComboBoxViewModel<Rarity> Rarity { get; }

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
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog();
            if (!(result.HasValue && result.Value)) { return; }
            if (ImageConfig.IsValidImageFile(dialog.FileName))
            {
                ImagePath = dialog.FileName;
            }
            else
            {
                MessageBox.Show($"This appears not to be a valid image file. Please try using a file with one of the following extensions: {string.Join(", ", ImageConfig.ValidExtensions)}", "Error");
            }
        }

        public CardTabViewModel([NotNull] IPokemon pokemon)
        {
            ContentViewModel = pokemon;
            HP = new CounterInputViewModel(ContentViewModel.HP);
            Level = new CounterInputViewModel(ContentViewModel.Level);
            Weakness = new ToggleableComboBoxViewModel<Type>(ContentViewModel.Weakness);
            Resistance = new ToggleableComboBoxViewModel<Type>(ContentViewModel.Resistance);
            Type = new ComboBoxViewModel<Type>(ContentViewModel.Type);
            Rarity = new ComboBoxViewModel<Rarity>(ContentViewModel.Rarity);

            OpenCommand = new RelayCommand(OpenFile);
        }

    }
}

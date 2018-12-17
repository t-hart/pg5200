using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using Editor.CardProperties;
using Editor.Config;
using Editor.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IO;
using JetBrains.Annotations;
using Microsoft.Win32;
using Type = Editor.CardProperties.Type;

namespace Editor.ViewModel
{
    public class CardTabViewModel : ViewModelBase, ITab<IPokemon>
    {
        public IPokemon ContentViewModel { get; set; }

        [NotNull] private readonly IImageLoader ImageLoader;
        [NotNull] private readonly IStorageService JsonService;

        [NotNull] public CounterInputViewModel HP { get; }
        [NotNull] public CounterInputViewModel Level { get; }
        [NotNull] public ToggleableComboBoxViewModel<Type> Weakness { get; }
        [NotNull] public ToggleableComboBoxViewModel<Type> Resistance { get; }
        [NotNull] public ComboBoxViewModel<Type> Type { get; }
        [NotNull] public ComboBoxViewModel<Rarity> Rarity { get; }

        public RelayCommand OpenCommand { get; }
        public RelayCommand ExportJsonCommand { get; }
        public RelayCommand ImportJsonCommand { get; }

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

        private void Alert(Exception e) => MessageBox.Show(e.Message);


        private void LoadImage()
        {
            var result = ImageLoader.Load();
            if (!result.Completed) { return; }

            if (result.IsOk)
            {
                ImagePath = result.Ok;
            }
            else
            {
                Alert(result.Err);
            }
        }

        private void PerformIO<T>(Func<IPokemon, IIOResult<T>> operation) where T : class
        {
            var result = operation(ContentViewModel);
            if (result.IsError) { Alert(result.Err);}
        }

        public CardTabViewModel([NotNull] IPokemon pokemon, [NotNull] IImageLoader imageLoader, [NotNull] IStorageService jsonService)
        {
            ContentViewModel = pokemon;
            ImageLoader = imageLoader;
            JsonService = jsonService;
            HP = new CounterInputViewModel(ContentViewModel.HP);
            Level = new CounterInputViewModel(ContentViewModel.Level);
            Weakness = new ToggleableComboBoxViewModel<Type>(ContentViewModel.Weakness);
            Resistance = new ToggleableComboBoxViewModel<Type>(ContentViewModel.Resistance);
            Type = new ComboBoxViewModel<Type>(ContentViewModel.Type);
            Rarity = new ComboBoxViewModel<Rarity>(ContentViewModel.Rarity);

            OpenCommand = new RelayCommand(LoadImage);
            ExportJsonCommand = new RelayCommand(() => PerformIO(JsonService.Save));
            ImportJsonCommand = new RelayCommand(() => PerformIO(JsonService.Load));
        }

    }
}

using Editor.CardProperties;
using Editor.Interfaces;
using GalaSoft.MvvmLight.Command;
using IO;
using JetBrains.Annotations;
using Type = Editor.CardProperties.Type;

namespace Editor.ViewModel
{
    public class CardTabViewModel : TabViewModel<IPokemon>
    {
        [NotNull] private readonly IImageLoader _imageLoader;

        [NotNull] public CounterInputViewModel HP { get; }
        [NotNull] public CounterInputViewModel Level { get; }
        [NotNull] public ToggleableComboBoxViewModel<Type> Weakness { get; }
        [NotNull] public ToggleableComboBoxViewModel<Type> Resistance { get; }
        [NotNull] public ComboBoxViewModel<Type> Type { get; }
        [NotNull] public ComboBoxViewModel<Rarity> Rarity { get; }

        public RelayCommand LoadImageCommand { get; }

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

        private void LoadImage()
        {
            var result = _imageLoader.Load();
            if (!result.Completed) { return; }

            if (result.IsOk)
            {
                ImagePath = result.Ok;
            }
            else
            {
                Utils.Alert(result.Err);
            }
        }

        protected override void ForceUpdate()
        {
            RaisePropertyChanged("");
            HP.RaisePropertyChanged("");
            Level.RaisePropertyChanged("");
            Weakness.RaisePropertyChanged("");
            Resistance.RaisePropertyChanged("");
            Type.RaisePropertyChanged("");
            Rarity.RaisePropertyChanged("");
        }

        public CardTabViewModel([NotNull] IPokemon pokemon, [NotNull] IImageLoader imageLoader, [NotNull] IStorageService jsonService)
            : base(jsonService)
        {
            ContentViewModel = pokemon;
            _imageLoader = imageLoader;
            HP = new CounterInputViewModel(ContentViewModel.HP);
            Level = new CounterInputViewModel(ContentViewModel.Level);
            Weakness = new ToggleableComboBoxViewModel<Type>(ContentViewModel.Weakness);
            Resistance = new ToggleableComboBoxViewModel<Type>(ContentViewModel.Resistance);
            Type = new ComboBoxViewModel<Type>(ContentViewModel.Type);
            Rarity = new ComboBoxViewModel<Rarity>(ContentViewModel.Rarity);

            LoadImageCommand = new RelayCommand(LoadImage);
        }

    }
}

using GalaSoft.MvvmLight;
using Editor.Model;
using Editor.Interfaces;

namespace Editor.ViewModel
{

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        //public CardTabViewModel Card { get; set; } = new CardTabViewModel(new Pokemon(name: "Gastly", modifier: "Claire's", dexEntry: "Almost invisible, this gaseous Pokémon cloaks the target and puts it to sleep without notice.", imageUrl: @"C:\Users\thomas\pg5200_card-creator\Editor\Assets/squirtle.png"));
        public CardTabViewModel Card { get; set; } = new CardTabViewModel(new Pokemon(name: "Gastly", modifier: "Claire's", dexEntry: "Almost invisible, this gaseous Pokémon cloaks the target and puts it to sleep without notice."));

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get => _welcomeTitle;
            set => Set(ref _welcomeTitle, value);
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });
        }

    }
}
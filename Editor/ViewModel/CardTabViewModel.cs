using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Editor.Interfaces;
using Editor.Model;
using GalaSoft.MvvmLight;

namespace Editor.ViewModel
{
    public class CardTabViewModel : ViewModelBase, ITab<IPokemon>
    {
        public IPokemon ContentViewModel { get; set; } = new Pokemon(name: "Pokegnome");

        public string Name
        {
            get => ContentViewModel.Name;
            set
            {
                if ((ContentViewModel.Name = value) == value) { return; }
                RaisePropertyChanged();
            }
        }
    }
}

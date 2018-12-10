using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Editor.Interfaces;
using Editor.Model;
using GalaSoft.MvvmLight;
using JetBrains.Annotations;

namespace Editor.ViewModel
{
    public class CardTabViewModel : ViewModelBase, ITab<IPokemon>
    {
        public IPokemon ContentViewModel { get; set; }

        public string Name
        {
            get => ContentViewModel.Name;
            set
            {
                if (Name == value) return;
                ContentViewModel.Name = value;
                RaisePropertyChanged("");
            }
        }
        public string Modifier
        {
            get => ContentViewModel.Modifier;
            set
            {
                if (Modifier == value) return;
                ContentViewModel.Modifier = value;
                RaisePropertyChanged("");
            }
        }
        public string DexEntry
        {
            get => ContentViewModel.DexEntry;
            set
            {
                if (DexEntry == value) return;
                ContentViewModel.DexEntry = value;
                RaisePropertyChanged("");
            }
        }
        public StatInputViewModel HP { get; set; }
        public StatInputViewModel Level { get; set; }


        public CardTabViewModel([NotNull] IPokemon contentViewModel)
        {
            ContentViewModel = contentViewModel;

            HP  = new StatInputViewModel(ContentViewModel.HP);
            Level  = new StatInputViewModel(ContentViewModel.Level);
        }

    }
}

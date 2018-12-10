using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

        [NotNull] public string Name
        {
            get => ContentViewModel.Name;
            set
            {
                if (Name == value) return;
                ContentViewModel.Name = value;
                RaisePropertyChanged("");
            }
        }
        [NotNull] public string Modifier
        {
            get => ContentViewModel.Modifier;
            set
            {
                if (Modifier == value) return;
                ContentViewModel.Modifier = value;
                RaisePropertyChanged("");
            }
        }
        [NotNull] public string DexEntry
        {
            get => ContentViewModel.DexEntry;
            set
            {
                if (DexEntry == value) return;
                ContentViewModel.DexEntry = value;
                RaisePropertyChanged("");
            }
        }
        [NotNull] public StatInputViewModel HP { get; set; }
        [NotNull] public StatInputViewModel Level { get; set; }

        [NotNull]
        public List<CardProperties.Type> Types { get; set; } =
            Enum.GetValues(typeof(CardProperties.Type)).Cast<CardProperties.Type>().ToList();

        public int Type
        {
            get => (int) ContentViewModel.Type;
            set
            {
                if (Type == value) { return; }
                ContentViewModel.Type = Types[value];
                RaisePropertyChanged("");
            }
        }


        public CardTabViewModel([NotNull] IPokemon contentViewModel)
        {
            ContentViewModel = contentViewModel;

            HP  = new StatInputViewModel(ContentViewModel.HP);
            Level  = new StatInputViewModel(ContentViewModel.Level);
        }

    }
}

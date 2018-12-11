using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using Editor.Interfaces;
using Editor.Model;
using GalaSoft.MvvmLight;
using JetBrains.Annotations;
using Type = Editor.CardProperties.Type;

namespace Editor.ViewModel
{
    public class CardTabViewModel : ViewModelBase, ITab<IPokemon>
    {
        public IPokemon ContentViewModel { get; set; }

        [NotNull] public StatInputViewModel HP { get; set; }
        [NotNull] public StatInputViewModel Level { get; set; }
        [NotNull] public ToggleableComboBoxViewModel<Type> Weakness { get; set; }
        [NotNull] public ToggleableComboBoxViewModel<Type> Resistance { get; set; }

        [NotNull]
        public List<CardProperties.Type> Types { get; set; } =
            Enum.GetValues(typeof(CardProperties.Type)).Cast<CardProperties.Type>().ToList();

        public int Type
        {
            get => (int)ContentViewModel.Type;
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

            HP = new StatInputViewModel(ContentViewModel.HP);
            Level = new StatInputViewModel(ContentViewModel.Level);
            Weakness = new ToggleableComboBoxViewModel<Type>(ContentViewModel.Weakness, "Weakness");
            Resistance = new ToggleableComboBoxViewModel<Type>(ContentViewModel.Resistance, "Resistance");
        }

    }
}

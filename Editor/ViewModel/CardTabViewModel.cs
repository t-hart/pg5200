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

        [NotNull] public CounterInputViewModel HP { get; }
        [NotNull] public CounterInputViewModel Level { get; }
        [NotNull] public ToggleableComboBoxViewModel<Type> Weakness { get; }
        [NotNull] public ToggleableComboBoxViewModel<Type> Resistance { get; }
        [NotNull] public ComboBoxViewModel<Type> Type { get; }



        public CardTabViewModel([NotNull] IPokemon contentViewModel)
        {
            ContentViewModel = contentViewModel;

            HP = new CounterInputViewModel(ContentViewModel.HP);
            Level = new CounterInputViewModel(ContentViewModel.Level);
            Weakness = new ToggleableComboBoxViewModel<Type>(ContentViewModel.Weakness);
            Resistance = new ToggleableComboBoxViewModel<Type>(ContentViewModel.Resistance);
            Type = new ComboBoxViewModel<Type>(ContentViewModel.Type);
        }

    }
}

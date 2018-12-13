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

        [NotNull] public StatInputViewModel HP { get; }
        [NotNull] public StatInputViewModel Level { get; }
        [NotNull] public ToggleableComboBoxViewModel<Type> Weakness { get; }
        [NotNull] public ToggleableComboBoxViewModel<Type> Resistance { get; }
        [NotNull] public ComboBoxLabeledViewModel<Type> Type { get; }
        [NotNull] public TextBoxLabeledViewModel<string> Modifier { get; }



        public CardTabViewModel([NotNull] IPokemon contentViewModel)
        {
            ContentViewModel = contentViewModel;

            HP = new StatInputViewModel(ContentViewModel.HP);
            Level = new StatInputViewModel(ContentViewModel.Level);
            Weakness = new ToggleableComboBoxViewModel<Type>(ContentViewModel.Weakness, "Weakness");
            Resistance = new ToggleableComboBoxViewModel<Type>(ContentViewModel.Resistance, "Resistance");
            Type = new ComboBoxLabeledViewModel<Type>(ContentViewModel.Type, "Type");
            Modifier = new TextBoxLabeledViewModel<string>(ContentViewModel.Modifier, "Modifier");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using JetBrains.Annotations;

namespace Editor.ViewModel
{
    public class ToggleableComboBoxViewModel<T>: ViewModelBase where T: Enum
    {
        [NotNull] public List<T> Options { get; } = Enum.GetValues(typeof(T)).Cast<T>().ToList();
        [NotNull] private ToggleableEnum<T>  Toggleable { get; }
        [NotNull] public string Label { get; }

        public int CurrentIndex
        {
            get => Convert.ToInt32(Toggleable.Current);
            set
            {
                if (CurrentIndex == value) { return; }
                Toggleable.Current = Options[value];
                RaisePropertyChanged("");
            }
        }

        public bool IsActive
        {
            get => Toggleable.IsActive;
            set => Toggleable.IsActive = value;
        }

        public ToggleableComboBoxViewModel([NotNull] ToggleableEnum<T> toggleable, [NotNull] string label)
        {
            Label = label;
            Toggleable = toggleable;
        }
    }
}

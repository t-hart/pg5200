using System;
using System.Collections.Generic;
using System.Linq;
using Editor.ViewModel.Interfaces;
using GalaSoft.MvvmLight;
using JetBrains.Annotations;

namespace Editor.ViewModel
{
    public class ToggleableComboBoxViewModel<T> : ViewModelBase, IToggleableComboBoxViewModel<T> where T : Enum
    {
        [NotNull] public List<T> Options { get; } = Enum.GetValues(typeof(T)).Cast<T>().ToList();
        [NotNull] private IToggleableEnum<T> Toggleable { get; }

        public int CurrentIndex
        {
            get => Convert.ToInt32(Toggleable.Value);
            set
            {
                if (CurrentIndex == value) { return; }
                Toggleable.Value = Options[value];
                RaisePropertyChanged("");
            }
        }

        public bool IsActive
        {
            get => Toggleable.IsActive;
            set
            {
                if (IsActive == value) { return; }
                Toggleable.IsActive = value;
                RaisePropertyChanged("");
            }
        }

        public ToggleableComboBoxViewModel([NotNull] IToggleableEnum<T> toggleable)
        {
            Toggleable = toggleable;
        }
    }
}

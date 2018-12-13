using System;
using System.Collections.Generic;
using System.Linq;
using Editor.ViewModel.Interfaces;
using GalaSoft.MvvmLight;
using JetBrains.Annotations;

namespace Editor.ViewModel
{
    public class ComboBoxViewModel<T> : ViewModelBase, IComboBoxViewModel<T> where T : Enum
    {
        [NotNull] public List<T> Options { get; } = Enum.GetValues(typeof(T)).Cast<T>().ToList();
        private T _current;

        public int CurrentIndex
        {
            get => Convert.ToInt32(_current);
            set
            {
                if (CurrentIndex == value) { return; }
                _current = Options[value];
                RaisePropertyChanged("");
            }
        }

        public ComboBoxViewModel(T current)
        {
            _current = current;
        }
    }
}

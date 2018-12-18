using System;
using System.Collections.Generic;
using System.Linq;
using CardCreator.ViewModel.Interfaces;
using GalaSoft.MvvmLight;
using JetBrains.Annotations;

namespace CardCreator.ViewModel
{
    public class ComboBoxViewModel<T> : ViewModelBase, IComboBoxViewModel<T> where T : Enum
    {
        [NotNull] public List<T> Options { get; } = Enum.GetValues(typeof(T)).Cast<T>().ToList();
        private readonly IReferenceEnum<T> _current;

        public int CurrentIndex
        {
            get => Convert.ToInt32(_current.Value);
            set
            {
                if (CurrentIndex == value) { return; }
                _current.Value = Options[value];
                RaisePropertyChanged("");
            }
        }

        public ComboBoxViewModel(IReferenceEnum<T> current)
        {
            _current = current;
        }
    }
}

using System.Collections.Generic;
using Editor.ViewModel.Interfaces;
using GalaSoft.MvvmLight;
using JetBrains.Annotations;

namespace Editor.ViewModel
{
    public class TextBoxLabeledViewModel<T> : ViewModelBase, ILabeledInputViewModel<T> where T : class
    {
        [NotNull] public string Label { get; }
        [NotNull] private T _value;

        [NotNull]
        public T Value
        {
            get => _value;
            set
            {
                if (Value == value) { return; }
                _value = Value;
                RaisePropertyChanged("");

            }
        }

        public TextBoxLabeledViewModel([NotNull] T value, [NotNull] string label)
        {
            Label = label;
            _value = value;
        }
    }
}

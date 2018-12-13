using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Editor.ViewModel;
using Editor.ViewModel.Interfaces;
using GalaSoft.MvvmLight;
using JetBrains.Annotations;

namespace Editor.ViewModel
{
    public class ComboBoxLabeledViewModel<T> : ViewModelBase, IComboBoxViewModel<T> where T : Enum
    {
        [NotNull] public List<T> Options { get; } = Enum.GetValues(typeof(T)).Cast<T>().ToList();
        private T _current;
        [NotNull] public string Label { get; }

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

        public ComboBoxLabeledViewModel(T current, [NotNull] string label)
        {
            Label = label;
            _current = current;
        }
    }
}

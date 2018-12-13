using System;
using System.Windows.Input;
using Editor.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using JetBrains.Annotations;

namespace Editor.ViewModel
{
    public class CounterInputViewModel : ViewModelBase
    {
        [NotNull] public ICounter Counter { get; }
        public ICommand IncrementCommand { get; }
        public ICommand DecrementCommand { get; }

        public CounterInputViewModel([NotNull] ICounter counter)
        {
            Counter = counter;

            void Update(Func<uint> updateField)
            {
                updateField();
                RaisePropertyChanged("");
            }

            IncrementCommand = new RelayCommand<ICounter>(x => Update(Counter.Increment));
            DecrementCommand = new RelayCommand<ICounter>(x => Update(Counter.Decrement));
        }
    }
}

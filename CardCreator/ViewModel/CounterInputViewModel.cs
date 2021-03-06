using System;
using System.Windows.Input;
using CardCreator.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using JetBrains.Annotations;

namespace CardCreator.ViewModel
{
    public class CounterInputViewModel : ViewModelBase
    {
        [NotNull] public ICounter Counter { get; }
        public ICommand IncrementCommand { get; }
        public ICommand DecrementCommand { get; }

        public CounterInputViewModel([NotNull] ICounter counter)
        {
            Counter = counter;

            void Update(Action updateField)
            {
                updateField();
                RaisePropertyChanged("");
            }

            IncrementCommand = new RelayCommand<ICounter>(x => Update(Counter.Increment));
            DecrementCommand = new RelayCommand<ICounter>(x => Update(Counter.Decrement));
        }
    }
}

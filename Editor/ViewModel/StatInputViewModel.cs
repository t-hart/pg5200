using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Editor.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using JetBrains.Annotations;

namespace Editor
{
    public class StatInputViewModel : ViewModelBase
    {
        [NotNull] public IStat Stat { get; }
        public ICommand IncrementCommand { get; }
        public ICommand DecrementCommand { get; }

        public StatInputViewModel([NotNull] IStat stat)
        {
            Stat = stat;

            void Update(Func<uint> updateField)
            {
                updateField();
                RaisePropertyChanged("");
            }

            IncrementCommand = new RelayCommand<ICounter>(x => Update(Stat.Increment));
            DecrementCommand = new RelayCommand<ICounter>(x => Update(Stat.Decrement));
        }
    }
}

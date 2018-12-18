using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Editor.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IO;
using JetBrains.Annotations;

namespace Editor.ViewModel
{
    public abstract class TabViewModel<T> : ViewModelBase, ITab<T> where T : class, IResettable
    {
        public T ContentViewModel { get; set; }

        [NotNull] private readonly IStorageService _jsonService;
        [NotNull] public RelayCommand ResetCommand { get; }
        [NotNull] public RelayCommand ExportJsonCommand { get; }
        [NotNull] public RelayCommand ImportJsonCommand { get; }


        protected abstract void ForceUpdate();

        protected TabViewModel([NotNull] IStorageService jsonService)
        {
            _jsonService = jsonService;
            ExportJsonCommand = new RelayCommand(() => Utils.PerformIO(() => _jsonService.Save(ContentViewModel)));
            ImportJsonCommand = new RelayCommand(() =>
            {
                Utils.PerformIO(() => _jsonService.Load(ContentViewModel));
                ForceUpdate();
            });
            ResetCommand = new RelayCommand(() =>
            {
                ContentViewModel.Reset();
                ForceUpdate();
            });
        }
    }
}

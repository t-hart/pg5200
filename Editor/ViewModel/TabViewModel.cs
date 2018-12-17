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

        // ReSharper disable once InconsistentNaming
        private void PerformIO<U>(Func<T, IIOResult<U>> operation) where U : class
        {
            var result = operation(ContentViewModel);
            if (result.IsError) { Alert(result.Err); }
        }

        protected static void Alert(Exception e) => MessageBox.Show(e.Message);

        protected abstract void ForceUpdate();

        public TabViewModel([NotNull] IStorageService jsonService)
        {
            _jsonService = jsonService;
            ExportJsonCommand = new RelayCommand(() => PerformIO(_jsonService.Save));
            ImportJsonCommand = new RelayCommand(() =>
            {
                PerformIO(_jsonService.Load);
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

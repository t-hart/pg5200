using System;
using System.Collections.Generic;

namespace Editor.ViewModel.Interfaces
{
    public interface IComboBoxViewModel<T> where T : Enum
    {
        string Label { get; }

        int CurrentIndex { get; set; }

        List<T> Options { get; }
    }
}

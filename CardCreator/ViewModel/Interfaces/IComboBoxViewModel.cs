using System;
using System.Collections.Generic;

namespace CardCreator.ViewModel.Interfaces
{
    public interface IComboBoxViewModel<T> where T : Enum
    {
        int CurrentIndex { get; set; }

        List<T> Options { get; }
    }
}

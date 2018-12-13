using System;

namespace Editor.ViewModel.Interfaces
{
    public interface IToggleableComboBoxViewModel<T> : IComboBoxViewModel<T> where T : Enum
    {
        bool IsActive { get; set; }
    }
}

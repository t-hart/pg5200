using System;

namespace Editor.ViewModel.Interfaces
{
    public interface IToggleableEnum<T> where T : Enum
    {
        bool IsActive { get; set; }
        T Current { get; set; }
    }
}

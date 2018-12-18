using System;

namespace CardCreator.ViewModel.Interfaces
{
    public interface IToggleableEnum<T> : IReferenceEnum<T> where T : Enum
    {
        bool IsActive { get; set; }
    }
}

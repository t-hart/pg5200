using System;
using CardCreator.ViewModel.Interfaces;

namespace CardCreator.ViewModel
{
    public class ToggleableEnum<T> : IToggleableEnum<T> where T: Enum
    {
        public bool IsActive { get; set; }
        public T Value { get; set; }

        public ToggleableEnum(T current, bool isActive)
        {
            IsActive = isActive;
            Value = current;
        }
    }
}

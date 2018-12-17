using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Editor.ViewModel.Interfaces;

namespace Editor.ViewModel
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

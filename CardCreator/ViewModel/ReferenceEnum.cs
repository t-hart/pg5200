using System;

namespace CardCreator.ViewModel
{
    public class ReferenceEnum<T> : IReferenceEnum<T> where T : Enum
    {
        public T Value { get; set; }

        public ReferenceEnum(T current)
        {
            Value = current;
        }
    }
}

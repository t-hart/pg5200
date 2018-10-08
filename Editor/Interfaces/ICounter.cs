using System;

namespace Editor.Interfaces
{
    public interface ICounter
    {
        uint Value { get; set; }
        Func<uint> Increment { get; }
        Func<uint> Decrement { get; }
    }
}

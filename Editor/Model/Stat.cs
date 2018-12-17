using System;
using Editor.Interfaces;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Editor.Model
{
    public abstract class Stat : IStat
    {
        private readonly Values _values;

        public string Name { get; }

        private uint _currentValue;
        public uint Value
        {
            get => _currentValue;
            set => _currentValue = Clamp(value);
        }

        public abstract void Increment();
        public abstract void Decrement();
        protected abstract uint Clamp(uint value);

        private Stat(Values values, [NotNull] string name)
        {
            _values = values;
            Name = name;
        }

        public abstract class PointStat : Stat
        {
            public sealed override void Decrement() => Value -= 10;
            public sealed override void Increment() => Value += 10;
            protected sealed override uint Clamp(uint x) =>
                x < _values.Min || x >= uint.MaxValue - x ? _values.Min
                : x > _values.Max ? _values.Max
                : (uint) (Math.Round(x / 10d) * 10);

            protected PointStat(Values values, [NotNull] string name, uint value) : base(values, name)
            {
                Value = Clamp(value);
            }
        }

        public sealed class HP : PointStat
        {
            public HP(uint value) : base(new Values {Min = 10, Max = 200, Default = 30}, "HP", value) { }
        }

        public sealed class Damage : PointStat
        {
            public Damage(uint value) : base(new Values {Min = 0, Max = 150, Default = 10}, "Damage", value) { }
        }

        public sealed class Level : Stat
        {
            public override void Decrement() => Value -= 1;
            public override void Increment() => Value += 1;

            protected override uint Clamp(uint x) =>
                x < _values.Min || x >= uint.MaxValue - x ? _values.Min
                : x > _values.Max ? _values.Max
                : x;

            public Level(uint value) : base(new Values {Min = 1, Max = 100, Default = 5}, "Level")
            {
                Value = Clamp(value);
            }
        }


        public IResettable Reset()
        {
            Value = _values.Default;
            return this;
        }

        protected struct Values
        {
            public uint Min { get; set; }
            public uint Max { get; set; }
            public uint Default { get; set; }
        }
    }
}

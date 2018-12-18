using System;
using CardCreator.Interfaces;
using JetBrains.Annotations;

namespace CardCreator.Model
{
    public abstract class Stat : IStat
    {
        private readonly Values _values;

        [NotNull] public abstract string Name { get; }

        private uint _currentValue;
        public uint Value
        {
            get => _currentValue;
            set => _currentValue = Clamp(value);
        }

        public abstract void Increment();
        public abstract void Decrement();
        protected abstract uint Clamp(uint value);

        private Stat(Values values)
        {
            _values = values;
        }

        public abstract class PointStat : Stat
        {
            public sealed override void Decrement() => Value -= 10;
            public sealed override void Increment() => Value += 10;
            protected sealed override uint Clamp(uint x) =>
                x < _values.Min || x >= uint.MaxValue - x ? _values.Min
                : x > _values.Max ? _values.Max
                : (uint) (Math.Round(x / 10d) * 10);

            protected PointStat(Values values, uint value) : base(values)
            {
                Value = Clamp(value);
            }
        }

        public sealed class HP : PointStat
        {
            public override string Name { get; } = "HP";
            public HP(uint value) : base(new Values {Min = 10, Max = 200, Default = 30}, value) { }
        }

        public sealed class Damage : PointStat
        {
            public override string Name { get; } = "Damage";
            public Damage(uint value) : base(new Values {Min = 0, Max = 150, Default = 10}, value) { }
        }

        public sealed class Level : Stat
        {
            public override string Name { get; } = "Level";
            public override void Decrement() => Value -= 1;
            public override void Increment() => Value += 1;

            protected override uint Clamp(uint x) =>
                x < _values.Min || x >= uint.MaxValue - x ? _values.Min
                : x > _values.Max ? _values.Max
                : x;

            public Level(uint value) : base(new Values {Min = 1, Max = 100, Default = 5})
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

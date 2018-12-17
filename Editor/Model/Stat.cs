using System;
using Editor.Interfaces;
using JetBrains.Annotations;

namespace Editor.Model
{
    public sealed class Stat : IStat
    {
        private readonly Values _values;

        public string Name { get; }

        private readonly Func<uint, uint> _clamp;
        public Func<uint> Decrement { get; }
        public Func<uint> Increment { get; }

        private uint _currentValue;
        public uint Value
        {
            get => _currentValue;
            set => _currentValue = _clamp(value);
        }

        private Stat(Values values, Functions fs, [NotNull] string name, uint value)
        {
            _values = values;
            Name = name;
            Increment = () => Value = fs.Increment(Value);
            Decrement = () => Value = fs.Decrement(Value);
            _clamp = x => fs.Clamp(_values.Min, _values.Max, x);
            _currentValue = _clamp(value);
        }

        public static Stat Level(uint value) =>
            new Stat(
                new Values { Min = 1, Max = 100, Default = 5 },
                new Functions
                {
                    Increment = x => x + 1,
                    Decrement = x => x - 1,
                    Clamp = (min, max, x) => x > max ? max : x < min ? min : x
                },
                "Level", value);

        private static Stat PointStat(Values values, string name, uint value) =>
            new Stat(values, new Functions
            {
                Increment = x => x + 10,
                Decrement = x => x - 10,
                Clamp = (min, max, x) => x > max ? max : x < min ? min : (uint)(Math.Round(x / 10d) * 10)
            },
            name, value);

        public static Stat HP(uint value) =>
            PointStat(new Values{ Min = 10, Max = 200, Default = 30}, "HP", value);

        public static Stat Damage(uint value) =>
            PointStat(new Values {Min = 0, Max = 150, Default = 10}, "Damage", value);


        public IResettable Reset()
        {
            Value = _values.Default;
            return this;
        }

        private struct Values
        {
            public uint Min { get; set; }
            public uint Max { get; set; }
            public uint Default { get; set; }
        }

        private struct Functions
        {
            public Func<uint, uint> Increment;
            public Func<uint, uint> Decrement;
            public Func<uint, uint, uint, uint> Clamp;
        }
    }
}

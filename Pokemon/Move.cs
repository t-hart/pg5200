using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Pokémon
{
    public struct Move
    {
        public Type Type { get; set; }
        public int Damage { get; set; }
        public bool AffectedByTypes { get; set; } // whether the move takes type information into account. Some moves bypass weakness, resistance, immunity
        [NotNull] public string Description { get; set; }
        public Dictionary<Energy<IType>, uint> EnergyCost { get; set; }
    }
}

using System.Collections.Generic;
using JetBrains.Annotations;

namespace Pokemon
{
    public struct IMove
    {
        [NotNull] string Name { get; set; }
        [NotNull] string Description { get; set; }
//        Type<IType> Type { get; set; }
        TypeEnum Type { get; set; }
        int Damage { get; set; }
//        IEffect PrimaryEffect { get; set; }
//        IEffect SecondaryEffect { get; set; }
        bool AffectedByTypes { get; set; } // whether the move takes type information into account. Some moves bypass weakness, resistance, immunity
        Dictionary<TypeEnum, uint> EnergyCost { get; set; }
    }
}

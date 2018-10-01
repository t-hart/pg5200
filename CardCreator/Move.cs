using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Pokemon
{
    public class Move
    {
        public Type Type { get; set; }
        public uint Power { get; set; }
        [NotNull] public string Description { get; set; }
    }
}

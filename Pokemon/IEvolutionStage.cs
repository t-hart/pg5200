using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    interface IEvolutionStage { }

    interface IBasic : IEvolutionStage { }

    interface IStage1 : IEvolutionStage
    {
        IBasic EvolvesFrom { get; }
    }

    interface IStage2 : IEvolutionStage
    {
        IStage1 EvolvesFrom { get; }
    }
}

using Prodicus.Interfaces;
using System;
using System.Collections.Generic;

namespace Prodicus.AppDataTypes
{
    public class GameStats : CompositeAppDataType
    {
        public override string Name => "GameStats";

        public override Guid DataTypeId => new Guid("{e8f811e3-4ee1-40c2-8c02-38e1e927f668}");


        public override List<AppDataType> Children => new List<AppDataType>()
        {
            new Time(),
            new Points(),
            new Team(),
            new PlayerName()
        };

        public override CellType CellType => CellType.Composite;
    }
}

using Prodicus.Interfaces;
using System;
using System.Collections.Generic;

namespace Prodicus.AppDataTypes
{
    public class Player : CompositeAppDataType
    {
        public override string Name => "Player";

        public override Guid DataTypeId => new Guid("{6cb57a45-f5be-47ab-806c-697f62fc644e}");


        public override List<AppDataType> Children => new List<AppDataType>()
        {
            new Id(),
            new Team(),
            new Position(),
            new PlayerName(),
            new Count(),
            new FantasyPoints(),
            new TeamComponent(),
            new Volatility(),
            new Weight(),
        };

        public override CellType CellType => CellType.Composite;
    }
}

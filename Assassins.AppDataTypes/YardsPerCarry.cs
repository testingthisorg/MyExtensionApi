using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class YardsPerCarry : AppDataType
    {

        public override string Name => "Yards per Carry";
        public override Guid DataTypeId => new Guid("c5e26701-9c23-4130-b04a-db2ec65ac637");

        public override CellType CellType => CellType.Decimal;
    }
}

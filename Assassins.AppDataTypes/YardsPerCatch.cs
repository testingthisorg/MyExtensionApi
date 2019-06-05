using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class YardsPerCatch : AppDataType
    {
        public override string Name => "Yards per Catch";
        public override Guid DataTypeId => new Guid("e7970330-8819-4976-b935-482090057245");

        public override CellType CellType => CellType.Double;

    }
}

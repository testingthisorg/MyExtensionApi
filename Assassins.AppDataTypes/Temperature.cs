using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class Temperature : AppDataType
    {
        public override string Name => "Temperature";
        public override Guid DataTypeId => new Guid("{22237c59-f260-42f1-9fec-a1a472077d53}");

        public override CellType CellType => CellType.Double;
    }
}

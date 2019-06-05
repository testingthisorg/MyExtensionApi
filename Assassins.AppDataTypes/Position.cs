using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class Position : AppDataType
    {
        public override string Name => "Position";

        public override Guid DataTypeId => new Guid("{a81f2d50-ee8d-4adf-8744-d1d88bf221c4}");

        public override CellType CellType => CellType.String;
    }
}

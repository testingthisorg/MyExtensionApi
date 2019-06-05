using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class Points : AppDataType
    {
        public override string Name => "Points";
        public override Guid DataTypeId => new Guid("{0371ba0b-1e57-4bbd-86f4-28eb3d9c1d77}");

        public override CellType CellType => CellType.Int32;
    }
}

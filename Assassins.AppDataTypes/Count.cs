using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class Count : AppDataType
    {
        public override string Name => "Count";

        public override Guid DataTypeId => new Guid("{04b81f20-05c0-419d-8ae5-d53daa0e2f48}");

        public override CellType CellType => CellType.Int32;
    }
}

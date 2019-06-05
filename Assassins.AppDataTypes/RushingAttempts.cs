using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class RushingAttempts : AppDataType
    {
        public override string Name => "Rushing Attempts";
        public override Guid DataTypeId => new Guid("{5f21b13e-4fcf-4019-b673-3bb5915eaf3f}");

        public override CellType CellType => CellType.Int32;
    }
}

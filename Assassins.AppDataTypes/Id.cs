using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class Id : AppDataType
    {
        public override string Name => "Id";

        public override Guid DataTypeId => new Guid("{97a7a5e4-fb30-41eb-b56b-5c5a29ece6bc}");

        public override CellType CellType => CellType.Int32;
    }
}

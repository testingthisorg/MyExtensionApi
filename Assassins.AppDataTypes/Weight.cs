using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class Weight : AppDataType
    {
        public override string Name => "Weight";

        public override Guid DataTypeId => new Guid("{52b72f72-583b-4e77-83e5-534ade97e157}");

        public override CellType CellType => CellType.Int32;
    }
}

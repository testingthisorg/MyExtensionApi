using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class Volatility : AppDataType
    {
        public override string Name => "Volatility";

        public override Guid DataTypeId => new Guid("{e206b135-d2ac-447f-bb62-a00ab0145734}");

        public override CellType CellType => CellType.Int32;
    }
}

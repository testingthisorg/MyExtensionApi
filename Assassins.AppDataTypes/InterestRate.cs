using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class IRYearly : AppDataType
    {
        public override string Name => "IR Yearly";

        public override Guid DataTypeId => new Guid("{6a2ad696-de0c-411a-be28-64120684379b}");

        public override CellType CellType => CellType.Decimal;
    }
}

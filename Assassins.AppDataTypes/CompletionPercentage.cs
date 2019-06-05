using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class CompletionPercentage : AppDataType
    {
        public override string Name => "Completion Percentage";
        public override Guid DataTypeId => new Guid("11481ff2-1993-4816-bc06-1721e926f066");

        public override CellType CellType => CellType.Double;
    }
}

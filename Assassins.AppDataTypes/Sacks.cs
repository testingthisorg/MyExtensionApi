using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class Sacks : AppDataType
    {
        public override string Name => "Sacks";
        public override Guid DataTypeId => new Guid("{6c05c0fe-0127-445a-8348-d9c7856b0166}");

        public override CellType CellType => CellType.Double;
    }
}

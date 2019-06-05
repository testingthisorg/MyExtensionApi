using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class Receptions : AppDataType
    {
        public override string Name => "Receptions";
        public override Guid DataTypeId => new Guid("{230ff475-7b5b-4ea1-832f-baa54706472b}");

        public override CellType CellType => CellType.Int32;
    }
}

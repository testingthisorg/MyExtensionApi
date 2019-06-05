using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class FantasyPoints : AppDataType
    {
        public override string Name => "Fantasy Points";

        public override Guid DataTypeId => new Guid("{be7816f3-4c45-4054-8964-0c649da311f0}");

        public override CellType CellType => CellType.Int32;
    }
}

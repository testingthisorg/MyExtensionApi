using Prodicus.Interfaces;
using System;


namespace Prodicus.AppDataTypes
{
    public class Touchdowns : AppDataType
    {
        public override string Name => "Touchdowns";
        public override Guid DataTypeId => new Guid("{b8eb07b0-56e0-45be-bdae-eb6462e1cd24}");

        public override CellType CellType => CellType.Int32;
    }
}

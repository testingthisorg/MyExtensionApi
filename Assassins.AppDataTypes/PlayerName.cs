using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class PlayerName : AppDataType
    {
        public override string Name => "PlayerName";

        public override Guid DataTypeId => new Guid("{71c9bb29-a2f8-4d02-a315-d744bc39fee8}");

        public override CellType CellType => CellType.String;
    }
}

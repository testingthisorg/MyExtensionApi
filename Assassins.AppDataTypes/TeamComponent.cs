using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class TeamComponent : AppDataType
    {
        public override string Name => "TeamComponent";

        public override Guid DataTypeId => new Guid("{4fb99ddb-d47c-47cf-9306-567f0f8da2a2}");

        public override CellType CellType => CellType.String;
    }
}

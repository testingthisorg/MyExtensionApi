using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class Team : AppDataType
    {
        public override string Name => "TeamName";

        public override Guid DataTypeId => new Guid("{ef4a0559-08f7-4d80-84f8-3a39407fa0ba}");

        public override CellType CellType => CellType.String;
    }
}
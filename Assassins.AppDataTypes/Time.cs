using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class Time : AppDataType
    {
        public override string Name => "Time";
        public override Guid DataTypeId => new Guid("{a0c280e3-da04-4e52-b9b8-716613242a1a}");

        public override CellType CellType => CellType.Int32;
    }
}

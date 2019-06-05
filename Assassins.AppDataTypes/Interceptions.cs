using Prodicus.Interfaces;
using System;
namespace Prodicus.AppDataTypes
{
    public class Interceptions : AppDataType
    {
        public override string Name => "Interceptions";
        public override Guid DataTypeId => new Guid("{39b2d9e3-b6a4-4235-8f00-7911237fcde9}");

        public override CellType CellType => CellType.Int32;
    }
}

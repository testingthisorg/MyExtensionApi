using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class StadiumAvgDecibel : AppDataType
    {
        public override string Name => "Stadium Avg Decibel";
        public override Guid DataTypeId => new Guid("{bd2301b3-de1c-4970-a149-b820619828f1}");

        public override CellType CellType => CellType.Double;
    }
}

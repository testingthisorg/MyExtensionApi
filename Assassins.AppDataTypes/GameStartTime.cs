using Prodicus.Interfaces;
using System;
namespace Prodicus.AppDataTypes
{
    public class GameStartTime : AppDataType
    {
        public override string Name => "Game Start Time";
        public override Guid DataTypeId => new Guid("{1c97f0a3-b883-4780-aa9b-c0203486459e}");

        public override CellType CellType => CellType.String;
    }
}

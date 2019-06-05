using Prodicus.Interfaces;
using System;

namespace Prodicus.AppDataTypes
{
    public class GameAttendance : AppDataType
    {
        public override string Name => "Game Attendance";
        public override Guid DataTypeId => new Guid("{687a1671-f83a-4bcd-8c05-839f7160998b}");

        public override CellType CellType => CellType.Int32;
    }
}

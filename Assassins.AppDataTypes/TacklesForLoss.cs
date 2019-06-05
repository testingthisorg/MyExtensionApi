using Prodicus.Interfaces;
using System;
namespace Prodicus.AppDataTypes
{
    public class TacklesForLoss : AppDataType
    {
        public override string Name => "Tackles For Loss";
        public override Guid DataTypeId => new Guid("{46f21c49-a83e-4aee-b425-2e626dab6f29}");

        public override CellType CellType => CellType.Double;
    }
}

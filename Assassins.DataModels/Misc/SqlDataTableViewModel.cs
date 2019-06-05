using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assassins.DataModels.Misc
{
    public class SqlDataTableViewModel
    {
        public SqlDataTableColumns Columns { get; set; }

    }

    public class SqlDataTableColumns {
        public string Id { get; set; }
        public string Header { get; set; }
        public string Accessor { get; set; }
        public bool Filterable { get; set; }
        public bool Resizable { get; set; }
        public int Width { get; set; }
        public string Cell { get; set; }
    }
}

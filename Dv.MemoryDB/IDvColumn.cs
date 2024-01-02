using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dv.MemoryDB
{
    public class IDvColumn
    {
        public string _name;
        public string Name { get => _name; set => _name = value; }

        public List<IDvCell> _rows;
        public List<IDvCell> Rows { get => _rows; set => _rows = value; }

        public Type ColumnType;
    }
}

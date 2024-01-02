using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dv.MemoryDB
{
    public class DvColumn<T> : IDvColumn
    {
        //private string _name;
        //public string Name { get => _name; set => _name = value; }

        //private List<IDvCell<T>> _rows;
        //public List<IDvCell<T>> Rows { get => _rows; set => _rows = value; }

        //public readonly Type ColumnType;


        public DvColumn(string name)
        {
            _name = name;
            _rows = new List<IDvCell>();
            ColumnType = typeof(T);
        }


        public DvColumn()
        {
            _rows = new List<IDvCell>();
            ColumnType = typeof(T);
        }

        //public DvColumn(Type type, string name, IDvCell cell)
        //{
        //    _name = name;
        //    _rows = new List<IDvCell>();
        //    cell.CheckType(type);
        //    _rows.Add(cell);
        //}

    }
}

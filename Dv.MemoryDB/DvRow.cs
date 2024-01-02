using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dv.MemoryDB
{
    public class DvRow
    {
        //private List<object> _columns;
        //public List<object> Columns { get => _columns; set => _columns = value; }


        //YES, I know I am duplicating column name in each row, but this is a start. Better than void
        private Dictionary<string, object> _columns = new Dictionary<string, object>();
        public Dictionary<string, object> Columns { get => _columns; set => _columns = value; }

        private List<IDvColumn> _dvcolumns = new List<IDvColumn>();
        public List<IDvColumn> Dvcolumns { get => _dvcolumns; set => _dvcolumns = value; }

        public string TableName;

        //public DvRow(params object[] values)
        //{
        //    id = Guid.NewGuid();
        //}

        public DvRow(string tableName)//, Dictionary<string, object> columns)
        {
            TableName = tableName;
            //check that the list of columns is actually a list of DvColumns
            //_columns = columns;
        }

        //public DvRow(DvTable table, params object[] values)
        //{
        //    TableName = table.Name;
        //    id = Guid.NewGuid();
        //    table.AddRowToTable(id);
        //}
    }
}

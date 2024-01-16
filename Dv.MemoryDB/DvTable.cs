using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dv.MemoryDB
{
    public class DvTable : IDvTable<DvTable>
    {
        private string _name;
        public string Name { get => _name; set => _name = value; }

        private List<IDvColumn> _columns;
        public List<IDvColumn> Columns
        {
            get
            {
                if (_columns == null)
                {
                    _columns = new List<IDvColumn>();
                }
                return _columns;
            }
            set
            {
                _columns = value;
            }
        }

        private List<DvRow> _rows;

        public List<DvRow> Rows
        {
            get
            {
                if (_rows == null)
                {
                    _rows = new List<DvRow>();
                }
                return _rows;
            }
            set
            {
                _rows = value;
            }
        }

        public DvTable(string name)
        {
            _name = name;

        }
        public DvTable()
        {

        }

        public void AddColumnToTable<T>(DvColumn<T> column) where T : DvColumn<T>
        {
            Columns.Add(column);
        }

        public void AddColumnToTable(IDvColumn column) 
        {
            Columns.Add(column);
        }

        public void AddRowToTable(DvRow dvRow)
        {
            Rows.Add(dvRow);
        }

        //public object GetObject(DvRow dvRow)
        //{

        //}

        //public DvRow ReadStringObject(string dvObject)
        //{

        //}

        public void Save(Object instance)
        {

            var someType = instance.GetType();
            DvRow instancex = new DvRow(someType.Name);
            foreach (var prop in instance.GetType().GetProperties())
            {

                if (prop.Name == "Name" || prop.Name == "Columns" || prop.Name == "Rows")
                {
                    continue;
                }
                //DvRow instancex = (DvRow)Activator.CreateInstance(someType);
                Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(instance, null));
                instancex.Columns.Add(prop.Name, prop.GetValue(instance, null));
                var propType = prop.PropertyType;
                IDvColumn dvcolumnx = new IDvColumn();
                DvTable? currentDvTable = DvContext.IsalreadyIncontext(instance);
                if (currentDvTable == null)
                {
                    dvcolumnx = (IDvColumn)Activator.CreateInstance(typeof(DvColumn<>).MakeGenericType(propType));
                    dvcolumnx.Name = prop.Name;
                    AddColumnToTable(dvcolumnx);
                }
                else
                {
                    foreach(var cl in currentDvTable.Columns)
                    {
                        if(prop.Name == cl.Name)
                        {
                            dvcolumnx = cl;
                            break;
                        }
                    }
                }

                dvcolumnx.Rows.Add(new DvCell(prop.GetValue(instance, null)));
                instancex.Dvcolumns.Add(dvcolumnx);

                //int repsonse = DvContext.AddToContext(instance);
            }
            Rows.Add(instancex);
            DvContext.UpdateContext(instance);
        }
    }
}

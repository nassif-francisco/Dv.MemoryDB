// See https://aka.ms/new-console-template for more information
using Dv.MemoryDB;
using System.ComponentModel;
using System.Xml.Linq;

Console.WriteLine("Hello, World!");
Users user = new Users("Vegeta");
user.ID = 1;
user.Save(user);

Users user2 = new Users("Goku");
user2.ID = 2;
user2.Save(user2);

namespace Dv.MemoryDB
{

    public class DvRow
    {
        //private List<object> _columns;
        //public List<object> Columns { get => _columns; set => _columns = value; }


        //YES, I know I am duplicating column name in each row, but this is a start. Better than void
        private Dictionary<string, object> _columns = new Dictionary<string, object>();
        public Dictionary<string, object> Columns { get => _columns; set => _columns = value; }

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

    internal class Users : DvTable
    {
        public string Username { get; set; }

        public int ID { get; set; }

        public Users(string name) : base(name)
        {
            Name = typeof(Users).Name;
            Username = name;
        }

        //public UsersTable(string name) : base(name)
        //{

        //}
    }

    public interface IDvCell<T>
    {

        T Value { get; }
        //you can change the change type later to adjust the check
        //whether it is column or item check
        //void CheckType(Type T)
        //{
        //    if (!Enum.IsDefined(typeof(DvColumnType), T))
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
    public class DvCell<T> : IDvCell<T>
    {

        private T _value;

        public T Value
        {
            get { return _value; }

            set { _value = value; }
        }

        public DvCell(T value)
        {
            _value = value;
        }

    }
    //public interface IDvType<T>
    //{

    //    void CheckType(Type T)
    //    {
    //        if (!Enum.IsDefined(typeof(DvColumnType), T))
    //        {
    //            throw new NotImplementedException();
    //        }
    //    }
    //}
    public class DvColumn<T>
    {
        private string _name;
        public string Name { get => _name; set => _name = value; }

        private List<IDvCell<T>> _rows;
        public List<IDvCell<T>> Rows { get => _rows; set => _rows = value; }

        public readonly Type ColumnType;


        public DvColumn(string name)
        {
            _name = name;
            _rows = new List<IDvCell<T>>();
            ColumnType = typeof(T);
        }


        public DvColumn()
        {
            _rows = new List<IDvCell<T>>();
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

    public class DvTable
    {
        private string _name;
        public string Name { get => _name; set => _name = value; }

        public List<Object> Columns;

        private static List<DvRow> _rows;

        public static List<DvRow> Rows
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

        public void AddColumnToTable<T>(DvColumn<T> column) where T : DvColumn<T>
        {
            Columns.Add(column);
        }

        public void AddRowToTable(DvRow dvRow)
        {
            Rows.Add(dvRow);
        }

        public void Save(Object instance)
        {

            var someType = instance.GetType();
            DvRow instancex = new DvRow(someType.Name);
            foreach (var prop in instance.GetType().GetProperties())
            {

                if (prop.Name == "Name")
                {
                    continue;
                }
                //DvRow instancex = (DvRow)Activator.CreateInstance(someType);
                Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(instance, null));
                instancex.Columns.Add(prop.Name, prop.GetValue(instance, null));

                //int repsonse = DvContext.AddToContext(instance);
            }
            Rows.Add(instancex);
            DvContext.UpdateContext(instance);
        }
    }

    internal class DvContext
    {
        private static DvContext _instance;

        private DvContext() { }

        public static DvContext GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DvContext();
            }
            return _instance;
        }

        public static int UpdateContext(object instance)
        {
            //check if ContextNode exists for the instance's type
            //create a new one in case it does not.
            //

            foreach (var tb in DvContext.GetTables())
            {
                //Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(instance, null));
                if (tb.Name == instance.GetType().Name)
                {
                    //tb.Rows.Add(instance);
                    //tb = instance;
                    //check if schema changed
                    //cn.UpdateContextNode(dvRow);
                    return 0;
                }
            }

            CreateTableAndAddToList(instance);
            return 0;
        }

        private static void CreateTableAndAddToList(object instance)
        {
            DvContext.GetTables().Add((DvTable)instance);
            UpdateContext(instance);
        }

        private static List<DvTable> DvTables;

        public static List<DvTable> GetTables()
        {
            if (DvTables == null)
            {
                DvTables = new List<DvTable>();
            }
            return DvTables;
        }
    }

}

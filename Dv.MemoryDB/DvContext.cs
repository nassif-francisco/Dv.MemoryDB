using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dv.MemoryDB
{
    public class DvContext
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

        public static DvTable? IsalreadyIncontext(object instance)
        {
            foreach (var tb in DvContext.GetTables())
            {
                //Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(instance, null));
                if (tb.Name == instance.GetType().Name)
                {
                    //tb.Rows.Add(instance);
                    //tb = instance;
                    //check if schema changed
                    //cn.UpdateContextNode(dvRow);
                    return tb;
                }
            }

            return null;
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

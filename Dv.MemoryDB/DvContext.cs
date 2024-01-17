using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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

        [System.Runtime.CompilerServices.MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentNamespace()
        {
            return Assembly.GetCallingAssembly().EntryPoint.DeclaringType.Namespace;
        }

        public static IEnumerable<Assembly> GetDvAssemblies()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var dvAssemblies = assemblies.Where(a => a.FullName.Contains("System").Equals(false));
            return dvAssemblies;
        }

        public static void CreateObjectsRuntime(Assembly? runtimeObjectAssembly, string? runtimeObject, Dictionary<string, object> properties)
        {
            //Assembly assembly = Assembly.GetExecutingAssembly();
            DvTable? currentTable = (DvTable)runtimeObjectAssembly?.CreateInstance(runtimeObject);
            Type? currentType = currentTable?.GetType();
            foreach (KeyValuePair<string, object> entry in properties)
            {
                PropertyInfo? propInfo = currentType?.GetProperty(entry.Key);
                propInfo?.SetValue(currentTable, entry.Value);
            }
            currentTable?.Save(currentTable);
            int a = 0;
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

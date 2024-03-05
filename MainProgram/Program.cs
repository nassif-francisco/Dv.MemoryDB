using Dv.MemoryDB;
using System.Collections.Specialized;
using System.Reflection;
using MainProgram;
using Dv.IOFileManager;
using CsvHelper.TypeConversion;

class TestClass
{
    static void Main(string[] args)
    {

        //TestReadObjectRuntime();
        TestReadFileAsync();
       
    }

    public static async void ReadFileAsync()
    {
        DvIOFileController dvIOFileController = new DvIOFileController("C:\\Dv.MemoryDB\\Users.csv");

        dvIOFileController.InitializeStreamReader();
        var className = await dvIOFileController.ReadCsvFirstLine();
        var parametersString = await dvIOFileController.ReadCsvParametersLine();
        string[] propertiesArray = parametersString.Split(",");

        Type userType = null;
        Assembly? runtimeObjectAssembly = null;
        FindAssemblyAndType(out userType, out runtimeObjectAssembly);
        string? userTypeFullName = userType != null ? userType?.FullName : "lol";

        await foreach(string st in dvIOFileController.ReadCsvFileLineByLineAsync())
        {
            //HAVE TO SPECIFY THE TYPES IN ANOTHER LINE, AFTER THE PARAMETERS
            object[] firstUserObject = st.Split(",");
            DvContext.CreateObjectRuntimeFromPropertyArray(runtimeObjectAssembly, userTypeFullName, propertiesArray, firstUserObject);
        }

    }

    public static void TestReadFileAsync()
    {
        ReadFileAsync();
    }

    public static void TestReadObjectRuntime()
    {
        //PART 2 Read objects at runtime
        //create object and save it

        Type userType = null;
        Assembly? runtimeObjectAssembly = null;
        FindAssemblyAndType(out userType, out runtimeObjectAssembly);

        string[] propertiesArray = new string[2];
        propertiesArray[0] = "Username";
        propertiesArray[1] = "ID";
        object[] firstUserObject = new object[2];
        firstUserObject[0] = "Vegeta";
        firstUserObject[1] = 1;


        string? userTypeFullName = userType != null ? userType?.FullName : "lol";
        DvContext.CreateObjectRuntimeFromPropertyArray(runtimeObjectAssembly, userTypeFullName, propertiesArray, firstUserObject);
    }

    public static void FindAssemblyAndType(out Type currentType, out Assembly? runtimeObjectAssembly)
    {
        currentType = null;
        runtimeObjectAssembly = null;
        var dvAssemblies = DvContext.GetDvAssemblies();

        bool foundType = false;

        foreach (Assembly assembly in dvAssemblies)
        {
            if (foundType)
            {
                break;
            }
            var assemblyTypes = assembly.GetTypes();
            foreach (Type type in assemblyTypes)
            {
                if (type.Name == "Users")
                {
                    currentType = type;
                    runtimeObjectAssembly = assembly;
                    foundType = true;
                    break;
                }
            }
        }
    }

    public static void TestSaveObjectRuntime()
    {
        //PART 1 Save objects at runtime
        Users user = new Users("Vegeta");
        user.ID = 1;
        user.Save(user);

        Users user2 = new Users("Goku");
        user2.ID = 2;
        user2.Save(user2);
    }
}

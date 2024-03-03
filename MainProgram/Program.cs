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
        //PART 1 Save objects at runtime
        //Users user = new Users("Vegeta");
        //user.ID = 1;
        //user.Save(user);

        //Users user2 = new Users("Goku");
        //user2.ID = 2;
        //user2.Save(user2);



        //PART 2 Read objects at runtime
        //create object and save it

        string usertable = "Dv.MemoryDB.Users";
        //Type userType = Type.GetType("MainProgram.Users");
        Type userType = null;
        Assembly? runtimeObjectAssembly = null;
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
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
                    userType = type;
                    runtimeObjectAssembly = assembly;
                    foundType = true;
                    break;
                }
            }
        }



        string currentNamespace = DvContext.GetCurrentNamespace();

        List<string> propertiesList = new List<string>() { "Username", "ID" };
        List<object> firstUser = new List<object>() { "Vegeta", 1 };

        string[] propertiesArray = new string[2];
        propertiesArray[0] = "Username";
        propertiesArray[1] = "ID";
        object[] firstUserObject = new object[2];
        firstUserObject[0] = "Vegeta";
        firstUserObject[1] = 1;


        string? userTypeFullName = userType != null ? userType?.FullName : "lol";
        DvContext.CreateObjectRuntimeFromPropertyList(runtimeObjectAssembly, userTypeFullName, propertiesArray, firstUserObject);
        Console.WriteLine(args.Length);


        ////PART 3 ... read file from csv
        ///
        //DvIOFileManager dvIOFileManager = new DvIOFileManager("C:\\Dv.MemoryDB\\Users.csv");
        //var content = dvIOFileManager.ReadCsvFile();
        //foreach (var item in content.ToList())
        //{
        //    Console.WriteLine(item);
        //}

        ReadFileAsync();
       
    }

    public static async void ReadFileAsync()
    {
        DvIOFileController<Users> dvIOFileController = new DvIOFileController<Users>("C:\\Dv.MemoryDB\\Users.csv");
        await foreach(string st in dvIOFileController.ReadCsvFileLineByLineAsync())
        {
            Console.WriteLine(st);
        }
       
    }
}

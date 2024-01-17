using Dv.MemoryDB;
using System.Collections.Specialized;
using System.Reflection;

class TestClass
{
    static void Main(string[] args)
    {
        //PART 1 Save objects at runtime
        //Users user = new Users("Vegeta");
        //user.ID= 1;
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
        {   if(foundType)
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
        string userColumns = "Username, ID";
        string userValues = "Vegeta, 1";
        Dictionary<string, object> userDict = new Dictionary<string, object>();
        userDict.Add("Username", "Vegeta");
        userDict.Add("ID", 1);
        string? userTypeFullName = userType != null ? userType?.FullName : "lol";
        DvContext.CreateObjectsRuntime(runtimeObjectAssembly, userTypeFullName, userDict);
        Console.WriteLine(args.Length);
    }
}

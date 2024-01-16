// See https://aka.ms/new-console-template for more information
using Dv.MemoryDB;
using System.ComponentModel;
using System.Reflection;
using System.Xml.Linq;


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
string userColumns = "Username, ID";
string userValues = "Vegeta, 1";
Dictionary<string, object> userDict = new Dictionary<string, object>();
userDict.Add("Username", "Vegeta");
userDict.Add("ID", 1);

DvContext.CreateObjectsRuntime(usertable, userDict);



namespace Dv.MemoryDB
{

    internal class Users : DvTable
    {
        public string Username { get; set; }

        public int ID { get; set; }

        public Users(string name) : base(name)
        {
            Name = typeof(Users).Name;
            Username = name;
        }
        public Users()
        {
            Name = typeof(Users).Name;
        }

        //public UsersTable(string name) : base(name)
        //{

        //}
    }

}

// See https://aka.ms/new-console-template for more information
using Dv.MemoryDB;
using System.ComponentModel;
using System.Xml.Linq;

Users user = new Users("Vegeta");
user.ID= 1;
user.Save(user);

Users user2 = new Users("Goku");
user2.ID = 2;
user2.Save(user2);

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

        //public UsersTable(string name) : base(name)
        //{

        //}
    }

}

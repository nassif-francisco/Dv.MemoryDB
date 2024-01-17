using Dv.MemoryDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MainProgram
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

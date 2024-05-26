using Dv.MemoryDB;

namespace Dv.Implementation
{
    public class Users : DvTable
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
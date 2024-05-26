using Xunit;
using Dv.Implementation;

namespace Dv.MemoryDB.Tests
{
    public class DvSaveObjectsAtRuntime
    {
        [Fact]
        public void DoCreateUserAndSaveIt()
        {
            //PART 1 Save objects at runtime
            Users user = new Users("Vegeta");
            user.ID = 1;
            user.Save(user);

            //assert Vegeta exists and its ID is 1

            Users user2 = new Users("Goku");
            user2.ID = 2;
            user2.Save(user2);

            //assert Goku exists and its ID is 1
            //assert Vegeta exists (it was not destroyed) and its ID is 1
        }
    }
}
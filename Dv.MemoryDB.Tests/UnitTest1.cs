using Xunit;
using Dv.Implementation;

namespace Dv.MemoryDB.Tests
{
    public class DvMainFunctions
    {
        [Fact]
        public void DoCreateUserAndSaveIt()
        {
            //PART 1 Save objects at runtime
            Users user = new Users("Vegeta");
            user.ID = 1;
            user.Save();

            //assert Vegeta exists and its ID is 1

            Users user2 = new Users("Goku");
            user2.ID = 2;
            user2.Save();

            //assert Goku exists and its ID is 1
            //assert Vegeta exists (it was not destroyed) and its ID is 1
        }


        [Fact]
        public void DoReadObjectsFromFile()
        {
            //read object from file and assert object exists in runtime
        }

        [Fact]
        public void DoModifyExistingObjectAndSave()
        {
            //read object from file and assert object exists in runtime
        }

        [Fact]
        public void DoModifyExistingObjectAndDoNotSave()
        {
            //read object from file and assert object exists in runtime
        }

        [Fact]
        public void DoModifyExistingObjectsAndSave()
        {
            //read object from file and assert object exists in runtime
        }

        [Fact]
        public void DoModifyExistingObjectsAndDoNotSave()
        {
            //read object from file and assert object exists in runtime
        }

        [Fact]
        public void DoReadObjectFromFileAndDropColumnsNoLongerPresentInClass()
        {
            //read object from file and assert object exists in runtime
        }

        [Fact]
        public void DoReadObjectFromFileAndAddNewColumnsInClass()
        {
            //read object from file and assert object exists in runtime
        }
    }
}
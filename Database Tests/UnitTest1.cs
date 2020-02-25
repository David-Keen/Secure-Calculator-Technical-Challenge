using NUnit.Framework;

namespace Database_Tests
{
    public class Tests
    {
        Database.IDatabaseContext database;
        [SetUp]
        public void Setup()
        {
            database = new Database.TestDatabase();
        }

        [Test]
        public void TestCanGetUserFromName()
        {
            Database.IUser user = database.GetUser("David", "Keen");
            Assert.NotNull(user);
            Assert.AreEqual(user.GetFullName("David Keen"));
        }
    }
}
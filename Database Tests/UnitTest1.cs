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
            Database.IUser user = database.GetUser("Test", "User");
            Assert.NotNull(user);
            Assert.AreEqual(user.GetFullName(), "Test User");
        }

        [Test]
        public void TestCanGetDavidKeenFromId0()
        {
            Database.IUser user = database.GetUser(0);
            Assert.NotNull(user);
            Assert.AreEqual(user.GetFullName(), "David Keen");
        }
    }
}
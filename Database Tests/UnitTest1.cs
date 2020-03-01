using NUnit.Framework;
using Calculator_Application.Database;

namespace Database_Tests
{
    public class Tests
    {
        IDatabaseContext database;
        [SetUp]
        public void Setup()
        {
            database = new TestDatabase();
        }

        [Test]
        public void TestCanGetUserFromName()
        {
            IUser user = database.GetUser("Test", "User");
            Assert.NotNull(user);
            Assert.AreEqual(user.GetFullName(), "Test User");
        }

        [Test]
        public void TestCanGetDavidKeenFromId0()
        {
            IUser user = database.GetUser(0);
            Assert.NotNull(user);
            Assert.AreEqual(user.GetFullName(), "David Keen");
        }
    }
}
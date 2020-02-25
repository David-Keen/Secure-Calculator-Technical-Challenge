using NUnit.Framework;

namespace Login_System_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestDoesGivePasswordAsMD5()
        {
            Login_System.Security.MD5HashedPassword password = new Login_System.Security.MD5HashedPassword("password");
            Assert.AreEqual("5F4DCC3B5AA765D61D8327DEB882CF99", password.GenerateHash());
        }

        [Test]
        public void TestDoesGiveDavidAsMD5()
        {
            Login_System.Security.MD5HashedPassword password = new Login_System.Security.MD5HashedPassword("David");
            Assert.AreEqual("464E07AFC9E46359FB480839150595C5", password.GenerateHash());
        }

        [Test]
        public void TestCompareMatchesWithPasswordAsPassword()
        {
            Login_System.Security.IPassword userInputPassword = new Login_System.Security.MD5HashedPassword("password");
            Login_System.Security.IPassword databasePassword = new Login_System.Security.MD5HashedPassword("password");

            Assert.IsTrue(userInputPassword.MatchesHash(databasePassword.GenerateHash()));
        }

        [Test]
        public void TestCompareMatchesWithPasswordAsDavid()
        {
            Login_System.Security.IPassword userInputPassword = new Login_System.Security.MD5HashedPassword("David");
            Login_System.Security.IPassword databasePassword = new Login_System.Security.MD5HashedPassword("David");

            Assert.IsTrue(userInputPassword.MatchesHash(databasePassword.GenerateHash()));
        }

        [Test]
        public void TestCompareMatchesWithPasswordAsDavidButCaseChanged()
        {
            Login_System.Security.IPassword userInputPassword = new Login_System.Security.MD5HashedPassword("David");
            Login_System.Security.IPassword databasePassword = new Login_System.Security.MD5HashedPassword("david");

            Assert.IsFalse(userInputPassword.MatchesHash(databasePassword.GenerateHash()));
        }

        [Test]
        public void UserDavidKeenDoesExist()
        {
            Database.IDatabaseContext testDatabase = new Database.TestDatabase();
            Database.IUser david = testDatabase.GetUser("David", "Keen");
            Assert.AreEqual(david.GetFullName(), "David Keen");
        }

        [Test]
        public void DavidKeenDoesHaveAHashedPasswordOfPassword()
        {
            Database.IDatabaseContext testDatabase = new Database.TestDatabase();
            Login_System.Security.IPassword userInputPassword = new Login_System.Security.MD5HashedPassword("password");
            Database.IUser david = testDatabase.GetUser("David", "Keen");

            Assert.IsTrue(userInputPassword.MatchesHash(david.GetPasswordHash()));
        }

        [Test]
        public void DavidKeenDoesNotHaveAHashedPasswordOfPassword()
        {
            Database.IDatabaseContext testDatabase = new Database.TestDatabase();
            Login_System.Security.IPassword userInputPassword = new Login_System.Security.MD5HashedPassword("david");
            Database.IUser david = testDatabase.GetUser("David", "Keen");

            Assert.IsFalse(userInputPassword.MatchesHash(david.GetPasswordHash()));
        }
    }
}
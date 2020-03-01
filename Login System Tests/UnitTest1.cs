using NUnit.Framework;
using Calculator_Application.Security;
using Calculator_Application.Database;

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
            MD5HashedPassword password = new MD5HashedPassword("password");
            Assert.AreEqual("5F4DCC3B5AA765D61D8327DEB882CF99", password.GenerateHash());
        }

        [Test]
        public void TestDoesGiveDavidAsMD5()
        {
            MD5HashedPassword password = new MD5HashedPassword("David");
            Assert.AreEqual("464E07AFC9E46359FB480839150595C5", password.GenerateHash());
        }

        [Test]
        public void TestCompareMatchesWithPasswordAsPassword()
        {
            IPassword userInputPassword = new MD5HashedPassword("password");
            IPassword databasePassword = new MD5HashedPassword("password");

            Assert.IsTrue(userInputPassword.MatchesHash(databasePassword.GenerateHash()));
        }

        [Test]
        public void TestCompareMatchesWithPasswordAsDavid()
        {
            IPassword userInputPassword = new MD5HashedPassword("David");
            IPassword databasePassword = new MD5HashedPassword("David");

            Assert.IsTrue(userInputPassword.MatchesHash(databasePassword.GenerateHash()));
        }

        [Test]
        public void TestCompareMatchesWithPasswordAsDavidButCaseChanged()
        {
            IPassword userInputPassword = new MD5HashedPassword("David");
            IPassword databasePassword = new MD5HashedPassword("david");

            Assert.IsFalse(userInputPassword.MatchesHash(databasePassword.GenerateHash()));
        }

        [Test]
        public void UserDavidKeenDoesExist()
        {
            IDatabaseContext testDatabase = new TestDatabase();
            IUser david = testDatabase.GetUser("David", "Keen");
            Assert.AreEqual(david.GetFullName(), "David Keen");
        }

        [Test]
        public void DavidKeenDoesHaveAHashedPasswordOfPassword()
        {
            IDatabaseContext testDatabase = new TestDatabase();
            IPassword userInputPassword = new MD5HashedPassword("password");
            IUser david = testDatabase.GetUser("David", "Keen");

            Assert.IsTrue(userInputPassword.MatchesHash(david.GetPasswordHash()));
        }

        [Test]
        public void DavidKeenDoesNotHaveAHashedPasswordOfPassword()
        {
            IDatabaseContext testDatabase = new TestDatabase();
            IPassword userInputPassword = new MD5HashedPassword("david");
            IUser david = testDatabase.GetUser("David", "Keen");

            Assert.IsFalse(userInputPassword.MatchesHash(david.GetPasswordHash()));
        }
    }
}
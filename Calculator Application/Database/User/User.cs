using System;

namespace Calculator_Application.Database
{
    class User : IUser
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Id { get; private set; } = -1;
        private string passwordHash;

        public User (string firstName, string lastName, string passwordHash, int id = -1)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.passwordHash = passwordHash;
            this.Id = id;
        }
        public string GetFullName()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }

        public string GetPasswordHash()
        {
            return this.passwordHash;
        }
    }
}

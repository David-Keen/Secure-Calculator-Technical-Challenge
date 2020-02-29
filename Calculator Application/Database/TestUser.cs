using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_Application.Database
{
    public class TestUser : IUser
    {
        private string firstName;
        private string lastName;
        private int id = -1;

        public TestUser(int id)
        {
            this.id = id;
            if (id == 0)
            {
                this.firstName = "David";
                this.lastName = "Keen";
            }
        }

        public TestUser(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        string IUser.GetFullName()
        {
            return String.Format("{0} {1}", this.firstName, this.lastName);
        }

        string IUser.GetPasswordHash()
        {
            if (id == 0)
            {
                return "5F4DCC3B5AA765D61D8327DEB882CF99";
            }

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class TestDatabase : IDatabaseContext
    {
        IUser IDatabaseContext.GetUser(string firstName, string lastName)
        {
            return new TestUser(firstName, lastName);
        }

        IUser IDatabaseContext.GetUser(int id)
        {
            if (id == 0) return new TestUser(id);
            return null;
        }
    }
}

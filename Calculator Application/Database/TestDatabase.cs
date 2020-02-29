using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_Application.Database
{
    public class TestDatabase : IDatabaseContext
    {
        User.IUser IDatabaseContext.GetUser(string firstName, string lastName)
        {
            return new User.TestUser(firstName, lastName);
        }

        User.IUser IDatabaseContext.GetUser(int id)
        {
            if (id == 0) return new User.TestUser(id);
            return null;
        }
    }
}

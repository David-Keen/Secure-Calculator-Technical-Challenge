using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class TestDatabase : IDatabaseContext
    {
        IUser IDatabaseContext.GetUser(string firstName, string lastName)
        {
            if (firstName.ToLower() == "david" && lastName.ToLower() == "keen")
            {
                return new User("David", "Keen");
            }
            return null;
        }
    }
}

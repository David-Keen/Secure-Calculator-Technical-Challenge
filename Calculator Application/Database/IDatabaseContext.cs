using System;

namespace Calculator_Application.Database
{
    public interface IDatabaseContext
    {
        User.IUser GetUser(string firstName, string lastName);
        User.IUser GetUser(int id);
    }
}

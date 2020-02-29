using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_Application.Database.User
{
    public interface IUser
    {
        string GetFullName();
        string GetPasswordHash();
    }
}

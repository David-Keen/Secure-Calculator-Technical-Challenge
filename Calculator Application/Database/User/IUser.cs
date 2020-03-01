using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_Application.Database
{
    public interface IUser
    {
        string GetFullName();
        string GetPasswordHash();
    }
}

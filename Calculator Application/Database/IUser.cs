using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public interface IUser
    {
        string GetFullName();
        string GetPasswordHash();
    }
}

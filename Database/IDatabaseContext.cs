﻿using System;

namespace Database
{
    public interface IDatabaseContext
    {
        IUser GetUser(string firstName, string lastName);
        IUser GetUser(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Login_System.Security
{
    public abstract class IPassword
    {
        public abstract string GenerateHash();
        public abstract string GenerateHash(string message);
        public abstract bool MatchesHash(string hash);
    }
}

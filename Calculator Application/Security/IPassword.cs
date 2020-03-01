namespace Calculator_Application.Security
{
    public abstract class IPassword
    {
        public abstract string GenerateHash();
        public abstract string GenerateHash(string message);
        public abstract bool MatchesHash(string hash);
    }
}

using System.Text;

namespace Calculator_Application.Security
{
    public class MD5HashedPassword : IPassword
    {
        private string password;

        public MD5HashedPassword()
        {
        }

        public MD5HashedPassword(string password)
        {
            this.password = password;
        }

        public override string GenerateHash()
        {
            return this.GenerateHash(this.password);
        }

        public override string GenerateHash(string message)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(message);
            byte[] hashedBytes = md5.ComputeHash(inputBytes);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                builder.Append(hashedBytes[i].ToString("X2"));
            }
            return builder.ToString();
        }

        public override bool MatchesHash(string hash)
        {
            var hashToCheck = this.GenerateHash();
            return hashToCheck == hash;
        }
    }
}

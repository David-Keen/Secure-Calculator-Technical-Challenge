namespace Calculator_Application.Database
{
    public interface IUser
    {
        string GetFullName();
        string GetPasswordHash();
    }
}

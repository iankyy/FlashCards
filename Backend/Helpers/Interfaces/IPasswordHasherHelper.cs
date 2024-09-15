namespace Backend.Helpers.Interfaces
{
    public interface IPasswordHasherHelper
    {
        string Hash(string password);
        bool VerifyPassword(string password, string hashpassword);
    }
}

namespace eDnevnik___backend.Helpers;

public static class PasswordCheck
{
    public static bool CheckPasswords(string salt, string userPasswordHash, string loginPassword)
    {
        var loginPasswordHash = BCrypt.Net.BCrypt.HashPassword(loginPassword, salt);
        return userPasswordHash == loginPasswordHash;
    }
}
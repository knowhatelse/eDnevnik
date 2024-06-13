using eDnevnik___backend.Entities;

namespace eDnevnik___backend;

public class RoleManager<TEntiy>
{
    public static string GetRole(TEntiy user)
    {
        if (user is Admin) return "Admin";
        if (user is Teacher) return "Teacher";
        if (user is Parent) return "Parent";
        if (user is Student) return "Student";

        return string.Empty;
    }
}

namespace eDnevnik___backend.Entities
{
    public class Admin: User
    {
        public string? VerificationToken { get; set; }
        public bool? IsVerified { get; set; }
        
        public School? School { get; set; } = null;
    }
}

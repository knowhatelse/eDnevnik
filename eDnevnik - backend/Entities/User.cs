using System.ComponentModel.DataAnnotations;

namespace eDnevnik___backend.Entities
{
    public abstract class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string Role { get; set; } = null!;
        public string? Token2FA { get; set; }
        public bool? Enabled2FA { get; set; } = null;
        public int? SchoolId { get; set; } = null;

        public ContactInformation? ContactInformation { get; set; }
        public ICollection<Email> Emails { get; set; } = new List<Email>();
    }
}

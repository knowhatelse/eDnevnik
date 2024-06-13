using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace eDnevnik___backend.DTOs.UserDto
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Role { get; set; } = null!;
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public bool Enabled2FA { get; set; }

        [JsonIgnore]
        public string Token2FA { get; set; } = null!;
        [JsonIgnore]
        public string PasswordSalt { get; set; } = null!;
        [JsonIgnore]
        public string PasswordHash { get; set; } = null!;
        public int SchoolId { get; set; }
    }
}
